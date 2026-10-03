using MediatR;

namespace Template.Domain.Common.Events;

public abstract class Event : INotification
{
    public string MenssageType { get; protected init; }
    public Guid AggregateId { get; protected init; }
    public DateTime OccurredOn { get; private init; } = DateTime.Now;
}
