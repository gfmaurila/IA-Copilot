using Kit.Domain.Abstractions;
using Kit.Domain.Modules.Ai;
using Kit.Domain.Modules.Audit;
using Kit.Domain.Modules.Content;
using Kit.Domain.Modules.Identity;
using Kit.Domain.Modules.Media;
using Kit.Domain.Modules.Navigation;
using Kit.Domain.Modules.Notifications;

namespace Kit.Application.Abstractions.Repositories;

// Identity
public interface IOrganizationRepository : IRepository<Organization>;

public interface IGroupRepository : IRepository<Group>;

public interface IRoleRepository : IRepository<Role>;

// Content
public interface IContentTypeRepository : IRepository<ContentType>
{
    Task<ContentType?> FindBySlugAsync(string slug, CancellationToken cancellationToken = default);
}

public interface IContentItemRepository : IRepository<ContentItem>
{
    Task<IReadOnlyList<ContentItem>> ListPublishedAsync(
        Guid contentTypeId,
        string? search,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default);

    Task<ContentItem?> FindBySlugAsync(string slug, CancellationToken cancellationToken = default);
}

public interface ITaxonomyRepository : IRepository<Taxonomy>;

public interface IMenuRepository : IRepository<Menu>
{
    Task<Menu?> FindByNameAsync(string name, CancellationToken cancellationToken = default);
}

// Media
public interface IMediaItemRepository : IRepository<MediaItem>;

// Notifications
public interface INotificationRepository : IRepository<Notification>
{
    Task<IReadOnlyList<Notification>> ListForRecipientAsync(
        Guid recipientUserId,
        bool onlyUnread,
        CancellationToken cancellationToken = default);
}

// Audit: append only, by design. There is no Update and no Remove in the
// contract, which is what makes the trail trustworthy.
public interface IAuditEntryRepository
{
    Task AddAsync(AuditEntry entry, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<AuditEntry>> ListAsync(
        string? resource,
        string? resourceId,
        Guid? actorId,
        CancellationToken cancellationToken = default);
}

// AI
public interface IAiAgentRepository : IRepository<AiAgent>
{
    Task<AiAgent?> FindByNameAsync(string name, CancellationToken cancellationToken = default);
}

public interface IAiToolDefinitionRepository : IRepository<AiToolDefinition>
{
    Task<AiToolDefinition?> FindByNameAsync(string name, CancellationToken cancellationToken = default);
}