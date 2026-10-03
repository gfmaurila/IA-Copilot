using Kit.Application.Abstractions.Repositories;
using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Domain.Modules.Ai;
using Kit.Domain.Modules.Audit;
using Kit.Domain.Modules.Identity;
using Kit.Domain.Modules.Media;
using Kit.Domain.Modules.Notifications;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Repositories.Modules;

public sealed class MediaItemRepository : EfRepository<MediaItem>, IMediaItemRepository
{
    public MediaItemRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }
}

public sealed class NotificationRepository : EfRepository<Notification>, INotificationRepository
{
    public NotificationRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    public async Task<IReadOnlyList<Notification>> ListForRecipientAsync(
        Guid recipientUserId,
        bool onlyUnread,
        CancellationToken cancellationToken = default)
    {
        var query = Query.Where(n => n.RecipientUserId == recipientUserId);

        if (onlyUnread)
        {
            query = query.Where(n => n.Status != NotificationStatus.Read);
        }

        return await query.OrderByDescending(n => n.CreatedAtUtc).ToListAsync(cancellationToken);
    }
}

public sealed class AuditEntryRepository : IAuditEntryRepository
{
    private readonly KitDbContext _context;

    public AuditEntryRepository(KitDbContext context) => _context = context;

    /// <summary>
    /// Audit entries are APPEND ONLY. There is no Update and no Remove: the write
    /// model has no operation that could alter history.
    /// </summary>
    public async Task AddAsync(AuditEntry entry, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entry);
        await _context.AuditEntries.AddAsync(entry, cancellationToken);
    }

    public async Task<IReadOnlyList<AuditEntry>> ListAsync(
        string? resource,
        string? resourceId,
        Guid? actorId,
        CancellationToken cancellationToken = default)
    {
        var query = _context.AuditEntries.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(resource))
        {
            var normalizedResource = resource.Trim();
            query = query.Where(e => e.Resource == normalizedResource);
        }

        if (!string.IsNullOrWhiteSpace(resourceId))
        {
            var normalizedResourceId = resourceId.Trim();
            query = query.Where(e => e.ResourceId == normalizedResourceId);
        }

        if (actorId.HasValue)
        {
            query = query.Where(e => e.ActorId == actorId.Value);
        }

        return await query.OrderByDescending(e => e.OccurredAtUtc).Take(500).ToListAsync(cancellationToken);
    }
}

public sealed class AiAgentRepository : EfRepository<AiAgent>, IAiAgentRepository
{
    public AiAgentRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    public Task<AiAgent?> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var normalized = name.Trim();
        return Query.FirstOrDefaultAsync(a => a.Name == normalized, cancellationToken);
    }
}

public sealed class AiToolDefinitionRepository : EfRepository<AiToolDefinition>, IAiToolDefinitionRepository
{
    public AiToolDefinitionRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    public Task<AiToolDefinition?> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var normalized = name.Trim();
        return Query.FirstOrDefaultAsync(t => t.Name == normalized, cancellationToken);
    }
}

public sealed class AgentExecutionRepository : EfRepository<AgentExecution>
{
    public AgentExecutionRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }
}

public sealed class KnowledgeBaseRepository : EfRepository<KnowledgeBase>
{
    public KnowledgeBaseRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }
}