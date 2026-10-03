namespace Kit.Domain.Common;

/// <summary>
/// Base class for Aggregate Roots.
/// Only Aggregate Roots may raise Domain Events, and only they are loaded and
/// saved as a whole through a repository - which is what guarantees that every
/// invariant is checked on every state change.
/// </summary>
public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot()
    {
    }

    protected AggregateRoot(Guid id)
        : base(id)
    {
    }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public bool HasDomainEvents => _domainEvents.Count > 0;

    public DomainNotificationCollection Notifications { get; } = new();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    protected void RaiseDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Clears the events after they have been dispatched. Called by
    /// Infrastructure once the events have been handed to the publisher.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void Notify(string code, string message) => Notifications.Add(code, message);
}