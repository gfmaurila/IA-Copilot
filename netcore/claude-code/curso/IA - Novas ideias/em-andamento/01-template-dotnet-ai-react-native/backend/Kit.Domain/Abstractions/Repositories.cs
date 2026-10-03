using Kit.Domain.Common;

namespace Kit.Domain.Abstractions;

/// <summary>
/// Repository contract owned by the Domain layer.
/// Generic over the Aggregate Root it loads, which prevents any consumer from
/// reaching an Entity directly - an Entity must always be loaded through its
/// Aggregate Root so all invariants are enforced.
/// </summary>
/// <typeparam name="TAggregate">Aggregate Root type.</typeparam>
public interface IRepository<TAggregate>
    where TAggregate : AggregateRoot
{
    Task<TAggregate?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TAggregate>> ListAsync(
        IReadOnlySpecification<TAggregate>? specification = null,
        CancellationToken cancellationToken = default);

    Task AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default);

    void Update(TAggregate aggregate);

    /// <summary>
    /// Removes an Aggregate Root. Whether this is a hard delete or a soft delete
    /// is decided by the implementation, never by the caller.
    /// </summary>
    void Remove(TAggregate aggregate);
}

/// <summary>
/// Minimal Specification contract used by repositories for composable queries
/// without leaking provider-specific query syntax into Application or Domain.
/// </summary>
public interface IReadOnlySpecification<TAggregate>
    where TAggregate : AggregateRoot
{
    bool IsSatisfiedBy(TAggregate aggregate);
}

/// <summary>
/// Unit of Work contract: the single transactional boundary of a use case.
/// Persists every tracked Aggregate Root atomically and publishes the Domain
/// Events collected during the transaction only after a successful commit.
/// </summary>
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Discards every in-memory change tracked in the current scope.
    /// </summary>
    void DiscardChanges();
}