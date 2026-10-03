using Kit.Producer;

namespace Kit.Consumer;

/// <summary>
/// Reacts to a Domain Event envelope that arrived from the bridge.
///
/// A handler is invoked once per subscribed topic per event, so it MUST be
/// idempotent: use <see cref="DomainEventMessage.EventId"/> to deduplicate
/// (for example by checking whether the notification or projection already
/// exists) instead of assuming at-most-once delivery.
///
/// Handlers run synchronously and must not throw for expected conditions. A
/// thrown exception makes the Consumer skip the offset commit, which means the
/// event will be redelivered; throwing carelessly therefore turns a transient
/// problem into an infinite retry loop.
/// </summary>
public interface IDomainEventHandler
{
    /// <summary>Name used only in logs. Keep it stable and descriptive.</summary>
    string Name { get; }

    /// <summary>
    /// Types of events this handler reacts to. An empty list means "all events".
    /// </summary>
    IReadOnlyCollection<string> SubscribedEvents { get; }

    void Handle(DomainEventMessage message);
}

/// <summary>
/// Convenience base: filters by <see cref="SubscribedEvents"/> so an
/// implementation only has to write the reaction, not the dispatch check.
/// </summary>
public abstract class DomainEventHandlerBase : IDomainEventHandler
{
    public abstract string Name { get; }

    public virtual IReadOnlyCollection<string> SubscribedEvents { get; } = [];

    public void Handle(DomainEventMessage message)
    {
        if (SubscribedEvents.Count > 0)
        {
            var matches = SubscribedEvents.Any(subscribed =>
                string.Equals(subscribed, message.EventName, StringComparison.OrdinalIgnoreCase));

            if (!matches)
            {
                return;
            }
        }

        Process(message);
    }

    protected abstract void Process(DomainEventMessage message);
}