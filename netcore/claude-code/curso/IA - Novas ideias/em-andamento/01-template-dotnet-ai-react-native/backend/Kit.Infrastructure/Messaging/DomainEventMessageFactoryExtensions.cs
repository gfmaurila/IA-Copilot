using System.Text.Json;
using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Producer;

namespace Kit.Infrastructure.Messaging;

public static class DomainEventMessageFactoryExtensions
{
    /// <summary>
    /// Serializes a Domain Event into the transport-agnostic envelope declared in
    /// Kit.Producer. The wire format lives outside the Domain on purpose.
    /// </summary>
    public static DomainEventMessage ToMessage(this IDomainEvent domainEvent) => new(
        domainEvent.EventId,
        domainEvent.EventName,
        domainEvent.OccurredAt,
        domainEvent.AggregateId,
        JsonSerializer.Serialize(domainEvent, domainEvent.GetType(), new JsonSerializerOptions(JsonSerializerDefaults.Web)));
}