using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kit.Infrastructure.Persistence;

/// <summary>
/// EF Core Unit of Work.
///
/// Responsibilities:
///  1. single transactional boundary for the whole use case;
///  2. maintenance of the optimistic concurrency token on every tracked entity;
///  3. collect the Domain Events raised during the transaction and publish them
///     ONLY after a successful commit - an event is never published for a
///     transaction that rolled back.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly KitDbContext _context;
    private readonly IDomainEventPublisher _publisher;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(
        KitDbContext context,
        IDomainEventPublisher publisher,
        ILogger<UnitOfWork> logger)
    {
        _context = context;
        _publisher = publisher;
        _logger = logger;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        StampAggregates();

        var aggregateRoots = _context.ChangeTracker
            .Entries<AggregateRoot>()
            .Where(e => e.Entity is Domain.Common.AggregateRoot)
            .ToList();

        var domainEvents = aggregateRoots
            .Where(e => e.Entity.HasDomainEvents)
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList();

        var affected = await _context.SaveChangesAsync(cancellationToken);

        foreach (var entry in aggregateRoots)
        {
            entry.Entity.ClearDomainEvents();
        }

        if (domainEvents.Count > 0)
        {
            _logger.LogInformation("Publishing {EventCount} domain event(s) after commit", domainEvents.Count);
            await _publisher.PublishAsync(domainEvents, cancellationToken);
        }

        return affected;
    }

    public void DiscardChanges()
    {
        foreach (var entry in _context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                case EntityState.Deleted:
                    // Never let a failed use case leave staged writes behind.
                    entry.State = EntityState.Detached;
                    break;

                case EntityState.Modified:
                    entry.CurrentValues.SetValues(entry.OriginalValues);
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }
    }

    private void StampAggregates()
    {
        foreach (var entry in _context.ChangeTracker.Entries<AggregateRoot>())
        {
            if (entry.State is EntityState.Added or EntityState.Modified)
            {
                entry.Entity.IncrementVersion();
            }
        }
    }
}