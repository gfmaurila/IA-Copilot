namespace Kit.Domain.Common;

/// <summary>
/// A Domain Validation expressed as data, so it can be collected and asserted
/// without relying on exceptions inside the aggregate.
/// </summary>
public sealed record DomainValidation(string Code, string Message) : IDomainValidation
{
    public static DomainValidation Create(string code, string message) => new(code, message);
}

/// <summary>
/// A Domain Notification expressed as data (non-blocking, post-persistence).
/// </summary>
public sealed record DomainNotification(string Code, string Message) : IDomainNotification
{
    public static DomainNotification Create(string code, string message) => new(code, message);
}

/// <summary>
/// Collects Domain Notifications raised by an aggregate during its lifetime.
/// </summary>
public sealed class DomainNotificationCollection
{
    private readonly List<DomainNotification> _notifications = [];

    public IReadOnlyList<DomainNotification> Notifications => _notifications;

    public bool HasNotifications => _notifications.Count > 0;

    public void Add(DomainNotification notification) => _notifications.Add(notification);

    public void Add(string code, string message) => _notifications.Add(new DomainNotification(code, message));

    public void Clear() => _notifications.Clear();
}

/// <summary>
/// Throws <see cref="DomainValidationException"/> when a blocking validation fails.
/// </summary>
public static class DomainAssert
{
    public static void IsTrue(
        bool condition,
        string code,
        string message)
    {
        if (!condition)
        {
            throw new DomainValidationException(new DomainValidation(code, message));
        }
    }

    public static void IsFalse(
        bool condition,
        string code,
        string message) => IsTrue(!condition, code, message);
}