using Confluent.Kafka;
using Microsoft.Extensions.Logging;

namespace Kit.Producer;

/// <summary>
/// Kafka implementation of the publish side.
///
/// Reliability rules:
///  - events are produced with Acks.All so the broker confirms the write before
///    the API reports the use case as committed;
///  - the Domain Event Id is the message key, which makes the bridge idempotent
///    for consumers (read models may discard duplicates by EventId);
///  - a delivery failure is logged and swallowed, because the Domain
///    transaction is already committed - losing a projection update must never
///    roll back business data. Use the audit trail to detect the gap.
/// </summary>
public sealed class KafkaEventProducer : IEventProducer, IDisposable
{
    private readonly IProducer<string, string> _producer;
    private readonly string _topicPrefix;
    private readonly ILogger<KafkaEventProducer> _logger;

    public KafkaEventProducer(string bootstrapServers, string topicPrefix, ILogger<KafkaEventProducer> logger)
    {
        _topicPrefix = topicPrefix.Trim('.');
        _logger = logger;

        var config = new ProducerConfig
        {
            BootstrapServers = bootstrapServers,
            Acks = Acks.All,
            EnableIdempotence = true,
            MessageSendMaxRetries = 5,
            ClientId = "kit-producer",
            LingerMs = 5
        };

        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public string BuildTopicName(string eventName) =>
        $"{_topicPrefix}.{eventName.ToLowerInvariant().Replace('.', '-')}";

    public async Task PublishAsync(
        IReadOnlyCollection<DomainEventMessage> messages,
        CancellationToken cancellationToken = default)
    {
        if (messages.Count == 0)
        {
            return;
        }

        var deliveries = new List<Task<DeliveryResult<string, string>>>(messages.Count);

        foreach (var message in messages)
        {
            var topic = BuildTopicName(message.EventName);

            var report = _producer.ProduceAsync(
                topic,
                new Message<string, string>
                {
                    Key = message.EventId.ToString(),
                    Value = message.PayloadJson,
                    Headers = new Headers
                    {
                        { "event-id", System.Text.Encoding.UTF8.GetBytes(message.EventId.ToString()) },
                        { "event-name", System.Text.Encoding.UTF8.GetBytes(message.EventName) },
                        { "occurred-at", System.Text.Encoding.UTF8.GetBytes(message.OccurredAt.ToString("O")) },
                        { "aggregate-id", System.Text.Encoding.UTF8.GetBytes(message.AggregateId?.ToString() ?? string.Empty) }
                    }
                });

            deliveries.Add(report);
        }

        try
        {
            await Task.WhenAll(deliveries);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Failed to publish {MessageCount} domain event(s) to Kafka. Business data is committed; the audit trail must be reconciled.",
                messages.Count);
        }
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(5));
        _producer.Dispose();
    }
}

/// <summary>
/// Used when messaging is disabled (Minimal mode). Keeps the in-process
/// Modular Monolith authoritative and makes the Kafka bridge an opt-in
/// integration rather than a correctness requirement.
/// </summary>
public sealed class NullEventProducer : IEventProducer
{
    public Task PublishAsync(
        IReadOnlyCollection<DomainEventMessage> messages,
        CancellationToken cancellationToken = default) => Task.CompletedTask;
}