using Template.Domain.Common.Events;

namespace Template.Domain.Common.Abstrations;

public abstract class BaseEntity : IEntity
{
    private readonly List<Event> _domainEvents = new();
    public IEnumerable<Event> DomainEvents => _domainEvents.AsReadOnly();
    public void AddDomainEvent(Event domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
