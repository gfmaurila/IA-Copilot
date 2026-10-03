namespace Kit.Producer;

/// <summary>
/// Publish-side contract of the messaging bridge. Keeping it in Kit.Producer
/// means Kit.Api never references a Kafka client type.
/// </summary>
public interface IEventProducer
{
    Task PublishAsync(IReadOnlyCollection<DomainEventMessage> messages, CancellationToken cancellationToken = default);
}

/// <summary>
/// Transport-agnostic message envelope shared by Kit.Producer and Kit.Consumer.
/// It is intentionally NOT a Domain Event: it is the serialized wire format, so
/// neither the Domain layer nor the consumer is coupled to the event's assembly.
/// The Domain Event Id travels in the message key, which is what makes
/// consumers idempotent.
/// </summary>
public sealed record DomainEventMessage(
    Guid EventId,
    string EventName,
    DateTime OccurredAt,
    Guid? AggregateId,
    string PayloadJson);