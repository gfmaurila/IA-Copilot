namespace Kit.Domain.Common;

/// <summary>
/// Base class for Domain Events. A Domain Event is a statement that something
/// meaningful happened inside the domain and that other parts of the system may
/// care about. Events are raised by the aggregate, collected by the AggregateRoot
/// and dispatched AFTER the Unit of Work commits.
/// </summary>
public interface IDomainEvent
{
    Guid EventId { get; }

    DateTime OccurredAt { get; }

    string EventName { get; }

    Guid? AggregateId { get; }
}

/// <summary>
/// Convenience base implementation for Domain Events.
/// </summary>
public abstract record DomainEventBase : IDomainEvent
{
    protected DomainEventBase(Guid? aggregateId = null)
    {
        AggregateId = aggregateId;
        OccurredAt = DateTime.UtcNow;
        EventId = Guid.NewGuid();
    }

    public Guid EventId { get; init; }

    public DateTime OccurredAt { get; init; }

    public abstract string EventName { get; }

    public Guid? AggregateId { get; init; }
}