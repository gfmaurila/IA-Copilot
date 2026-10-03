using System.Text.Json;
using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Infrastructure.Options;
using Kit.Producer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kit.Infrastructure.Messaging;

/// <summary>
/// Publishes Domain Events after commit.
///
/// When messaging is disabled (the default in Minimal mode) events are logged
/// and dropped: the Modular Monolith is authoritative in-process, and the Kafka
/// bridge is an opt-in integration, not a correctness requirement.
/// </summary>
public sealed class DomainEventPublisher : IDomainEventPublisher
{
    private readonly IEventProducer _producer;
    private readonly IOptions<MessagingOptions> _options;
    private readonly ILogger<DomainEventPublisher> _logger;

    public DomainEventPublisher(
        IEventProducer producer,
        IOptions<MessagingOptions> options,
        ILogger<DomainEventPublisher> logger)
    {
        _producer = producer;
        _options = options;
        _logger = logger;
    }

    public async Task PublishAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        if (domainEvents.Count == 0)
        {
            return;
        }

        if (!_options.Value.Enabled)
        {
            foreach (var domainEvent in domainEvents)
            {
                _logger.LogInformation(
                    "Domain event {EventName} raised by {AggregateId} (messaging disabled, not published)",
                    domainEvent.EventName,
                    domainEvent.AggregateId);
            }

            return;
        }

        var messages = domainEvents.Select(e => e.ToMessage()).ToList();
        await _producer.PublishAsync(messages, cancellationToken);
    }
}