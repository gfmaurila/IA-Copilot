using System.Text.Json;
using Confluent.Kafka;
using Kit.Producer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kit.Consumer;

/// <summary>
/// Consumes Domain Event envelopes published by Kit.Producer and hands each one
/// to the registered in-process handlers.
///
/// DESIGN RULE (important): the Consumer is a SIDE EFFECT, never the source of
/// truth. The API commits business data first and publishes afterwards, so if
/// this process is down, stopped, or never deployed at all, the platform is
/// still correct - it just has stale read models. Handlers must therefore be
/// idempotent and must never be the only place a rule is enforced.
/// </summary>
public sealed class KafkaEventConsumer : BackgroundService
{
    private static readonly TimeSpan IdlePollTimeout = TimeSpan.FromSeconds(1);

    private readonly KafkaConsumerOptions _options;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IReadOnlyList<IDomainEventHandler> _handlers;
    private readonly ILogger<KafkaEventConsumer> _logger;

    public KafkaEventConsumer(
        IOptions<KafkaConsumerOptions> options,
        IServiceScopeFactory scopeFactory,
        IEnumerable<IDomainEventHandler> handlers,
        ILogger<KafkaEventConsumer> logger)
    {
        _options = options.Value;
        _scopeFactory = scopeFactory;
        _handlers = handlers.ToList();
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Opt-in, exactly like the producer. With messaging disabled the Consumer
        // idles instead of failing, so the same compose file works with or
        // without Kafka.
        if (!_options.Enabled || string.IsNullOrWhiteSpace(_options.BootstrapServers))
        {
            _logger.LogInformation(
                "Messaging desativado. Kit.Consumer fica ocioso (a API continua sendo a fonte da verdade).");
            return;
        }

        var config = new ConsumerConfig
        {
            BootstrapServers = _options.BootstrapServers,
            GroupId = _options.ConsumerGroup,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false,
            // Commit happens only after every handler succeeded, so a crash
            // replays the event instead of silently losing it.
            EnableAutoOffsetStore = false,
            SessionTimeoutMs = 10_000,
            MaxPollIntervalMs = 300_000
        };

        using var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe(_options.Topics);

        _logger.LogInformation(
            "Assinando topicos {Topics} no grupo {Group}. {HandlerCount} handler(s) registrado(s).",
            string.Join(", ", _options.Topics),
            _options.ConsumerGroup,
            _handlers.Count);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ConsumeOne(consumer, stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
            // Graceful shutdown requested.
        }
        catch (ConsumeException exception)
        {
            _logger.LogError(exception, "Falha fatally no consumer Kafka: {Reason}", exception.Error.Reason);
            throw;
        }
        finally
        {
            consumer.Close();
        }

        await Task.CompletedTask;
    }

    private void ConsumeOne(IConsumer<string, string> consumer, CancellationToken stoppingToken)
    {
        ConsumeResult<string, string>? result;

        try
        {
            // A poll timeout would throw; polling with a real timeout keeps the
            // cancellation token honoured promptly on shutdown.
            result = consumer.Consume(TimeSpan.FromMilliseconds(500));
        }
        catch (ConsumeException exception)
        {
            _logger.LogError(exception, "Erro ao consumir: {Reason}", exception.Error.Reason);
            return;
        }

        if (result is null)
        {
            return;
        }

        var message = result.Message;

        if (message is null)
        {
            return;
        }

        DomainEventMessage? envelope;

        try
        {
            envelope = JsonSerializer.Deserialize<DomainEventMessage>(message.Value);
        }
        catch (JsonException exception)
        {
            // A malformed payload must not stall the partition: log it and move on.
            _logger.LogError(
                exception,
                "Payload invalido em {Topic}@{Offset}. A mensagem sera ignorada.",
                result.Topic,
                result.Offset.Value);
            consumer.StoreOffset(result);
            consumer.Commit(result);
            return;
        }

        if (envelope is null)
        {
            consumer.StoreOffset(result);
            consumer.Commit(result);
            return;
        }

        using var scope = _scopeFactory.CreateScope();

        foreach (var handler in _handlers)
        {
            var handlerType = handler.GetType().Name;

            try
            {
                handler.Handle(envelope);
                _logger.LogDebug("{Handler} processou {EventName} ({EventId})", handlerType, envelope.EventName, envelope.EventId);
            }
            catch (Exception exception)
            {
                // A failing handler must NOT commit the offset: the event is
                // redelivered on restart, which is why handlers have to be
                // idempotent.
                _logger.LogError(
                    exception,
                    "{Handler} falhou ao processar {EventName} ({EventId}). O offset NAO sera commitado.",
                    handlerType,
                    envelope.EventName,
                    envelope.EventId);
                return;
            }
        }

        consumer.StoreOffset(result);
        consumer.Commit(result);
    }
}

/// <summary>
/// Consumer-side configuration. Separate from MessagingOptions because the two
/// sides of the bridge are deployed and scaled independently.
/// </summary>
public sealed class KafkaConsumerOptions
{
    public const string SectionName = "Messaging";

    public bool Enabled { get; set; }

    public string? BootstrapServers { get; set; } = "localhost:9092";

    public string ConsumerGroup { get; set; } = "kit-consumer";

    /// <summary>
    /// Topic pattern. A trailing dot means "everything under this prefix", which
    /// is how the Consumer picks up Domain Events that are published as new types
    /// are added, without redeploying it.
    /// </summary>
    public string[] Topics { get; set; } = ["kit.*"];
}