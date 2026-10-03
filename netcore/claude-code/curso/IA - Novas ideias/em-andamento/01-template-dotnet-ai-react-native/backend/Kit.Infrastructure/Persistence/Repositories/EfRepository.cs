using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Repositories;

/// <summary>
/// Generic EF Core repository for Aggregate Roots.
///
/// Rules enforced here:
///  - only Aggregate Roots are reachable through this contract, so every load
///    re-establishes the aggregate boundary;
///  - the DbContext is change-tracked, because the Unit of Work owns the
///    transaction and the optimistic concurrency token;
///  - includes are declared explicitly by each concrete repository, never by
///    convention, so an endpoint can never trigger an accidental aggregate graph
///    load.
/// </summary>
public abstract class EfRepository<TAggregate> : IRepository<TAggregate>
    where TAggregate : AggregateRoot
{
    protected EfRepository(KitDbContext context, IClock clock)
    {
        Context = context;
        Clock = clock;
    }

    protected KitDbContext Context { get; }

    protected IClock Clock { get; }

    protected DbSet<TAggregate> Set => Context.Set<TAggregate>();

    /// <summary>Escape hatch for concrete repositories that need a provider-side query.</summary>
    protected IQueryable<TAggregate> Query => Set;

    /// <summary>Includes required for a correct aggregate load (children owned by the root).</summary>
    protected virtual IQueryable<TAggregate> ApplyIncludes(IQueryable<TAggregate> query) => query;

    public virtual async Task<TAggregate?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
        {
            return null;
        }

        return await ApplyIncludes(Query).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    /// <summary>
    /// Lists aggregates.
    /// IMPORTANT: when a specification is supplied it is evaluated IN MEMORY,
    /// because the Domain layer cannot produce a provider-specific expression.
    /// Concrete repositories therefore expose named query methods
    /// (e.g. FindByEmailAsync) for indexed lookups - never call this with a
    /// specification over a large table.
    /// </summary>
    public virtual async Task<IReadOnlyList<TAggregate>> ListAsync(
        IReadOnlySpecification<TAggregate>? specification = null,
        CancellationToken cancellationToken = default)
    {
        var query = ApplyIncludes(Query);

        if (specification is null)
        {
            return await query.ToListAsync(cancellationToken);
        }

        var all = await query.ToListAsync(cancellationToken);
        return [.. all.Where(specification.IsSatisfiedBy)];
    }

    public virtual async Task AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(aggregate);

        aggregate.SetTimestamps(Clock.UtcNow);
        await Set.AddAsync(aggregate, cancellationToken);
    }

    public virtual void Update(TAggregate aggregate)
    {
        ArgumentNullException.ThrowIfNull(aggregate);

        aggregate.SetTimestamps(Clock.UtcNow);
        Set.Update(aggregate);
    }

    public virtual void Remove(TAggregate aggregate)
    {
        ArgumentNullException.ThrowIfNull(aggregate);
        Set.Remove(aggregate);
    }
}