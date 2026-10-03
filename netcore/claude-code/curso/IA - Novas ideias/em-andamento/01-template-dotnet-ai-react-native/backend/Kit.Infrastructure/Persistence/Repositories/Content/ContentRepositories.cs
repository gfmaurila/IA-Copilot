using Kit.Application.Abstractions.Repositories;
using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Domain.Modules.Content;
using Kit.Domain.Modules.Navigation;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Repositories.Content;

public sealed class ContentTypeRepository : EfRepository<ContentType>, IContentTypeRepository
{
    public ContentTypeRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    protected override IQueryable<ContentType> ApplyIncludes(IQueryable<ContentType> query) => query
        .Include(t => t.Fields);

    public Task<ContentType?> FindBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var normalized = slug.Trim().ToLowerInvariant();
        return ApplyIncludes(Query).FirstOrDefaultAsync(t => t.Slug == normalized, cancellationToken);
    }
}

public sealed class ContentItemRepository : EfRepository<ContentItem>, IContentItemRepository
{
    public ContentItemRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    /// <summary>
    /// Versions are part of the aggregate: a load without them would let a caller
    /// edit an item and silently lose its history.
    /// </summary>
    protected override IQueryable<ContentItem> ApplyIncludes(IQueryable<ContentItem> query) => query
        .Include(i => i.Versions);

    public Task<ContentItem?> FindBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        var normalized = slug.Trim().ToLowerInvariant();
        return ApplyIncludes(Query).FirstOrDefaultAsync(i => i.Slug == normalized, cancellationToken);
    }

    public async Task<IReadOnlyList<ContentItem>> ListPublishedAsync(
        Guid contentTypeId,
        string? search,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var query = Query
            .Include(i => i.Versions)
            .Where(i => i.ContentTypeId == contentTypeId && i.Status == ContentStatus.Published);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim();
            query = query.Where(i => i.Title.Contains(term) || i.Slug.Contains(term));
        }

        return await query
            .OrderBy(i => i.PublishedAtUtc ?? i.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}

public sealed class TaxonomyRepository : EfRepository<Taxonomy>, ITaxonomyRepository
{
    public TaxonomyRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }
}

public sealed class MenuRepository : EfRepository<Menu>, IMenuRepository
{
    public MenuRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    /// <summary>
    /// The tree is at most two levels deep (a Domain rule of Menu), so a single
    /// Include is enough. Ordering is applied by the query, not by EF.
    /// </summary>
    protected override IQueryable<Menu> ApplyIncludes(IQueryable<Menu> query) => query
        .Include(m => m.Items);

    public Task<Menu?> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var normalized = name.Trim();
        return ApplyIncludes(Query).FirstOrDefaultAsync(m => m.Name == normalized, cancellationToken);
    }
}