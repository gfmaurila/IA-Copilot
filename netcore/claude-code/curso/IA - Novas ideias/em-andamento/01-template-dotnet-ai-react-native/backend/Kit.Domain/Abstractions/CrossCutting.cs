using Kit.Domain.Common;

namespace Kit.Domain.Abstractions;

/// <summary>
/// Publishes Domain Events after the Unit of Work commits.
/// The concrete transport (in-process, Kafka, outbox) lives in Infrastructure.
/// </summary>
public interface IDomainEventPublisher
{
    Task PublishAsync(
        IReadOnlyCollection<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Collects the current request context so Domain code can record who performed
/// an operation without depending on HttpContext.
/// </summary>
public interface ICurrentUser
{
    Guid? UserId { get; }

    Guid? OrganizationId { get; }

    string? Email { get; }

    IReadOnlyCollection<string> Permissions { get; }

    bool IsAuthenticated { get; }

    bool HasPermission(string permission);
}

/// <summary>
/// Abstraction over the system clock so tests can control time.
/// </summary>
public interface IClock
{
    DateTime UtcNow { get; }

    DateTimeOffset UtcNowOffset { get; }
}