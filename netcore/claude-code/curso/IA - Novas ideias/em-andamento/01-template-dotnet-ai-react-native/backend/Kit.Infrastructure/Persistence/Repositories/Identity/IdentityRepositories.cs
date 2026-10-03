using Kit.Application.Abstractions.Repositories;
using Kit.Domain.Abstractions;
using Kit.Domain.Common;
using Kit.Domain.Modules.Identity;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Repositories.Identity;

public sealed class UserRepository : EfRepository<User>, IUserRepository
{
    public UserRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    protected override IQueryable<User> ApplyIncludes(IQueryable<User> query) => query
        .Include(u => u.UserRoles)
        .Include(u => u.UserGroups)
        .Include(u => u.Sessions)
            .ThenInclude(s => s.RefreshTokens);

    /// <summary>
    /// Provider-side lookup by the normalized e-mail column. This is an
    /// infrastructure detail of the SAME aggregate - there is no second path
    /// around the User Aggregate.
    /// </summary>
    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalized = email.Trim().ToLowerInvariant();
        return ApplyIncludes(Query).FirstOrDefaultAsync(u => u.Email.Value == normalized, cancellationToken);
    }

    public Task<bool> ExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalized = email.Trim().ToLowerInvariant();
        return Query.AnyAsync(u => u.Email.Value == normalized, cancellationToken);
    }

    public async Task<IReadOnlyList<User>> ListByOrganizationAsync(Guid organizationId, CancellationToken cancellationToken = default)
        => await Query.Where(u => u.OrganizationId == organizationId).ToListAsync(cancellationToken);

    public Task<int> CountAsync(CancellationToken cancellationToken = default) => Query.CountAsync(cancellationToken);
}

public sealed class OrganizationRepository : EfRepository<Organization>, IOrganizationRepository
{
    public OrganizationRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    protected override IQueryable<Organization> ApplyIncludes(IQueryable<Organization> query) => query
        .Include(o => o.Teams);
}

public sealed class GroupRepository : EfRepository<Group>, IGroupRepository
{
    public GroupRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    protected override IQueryable<Group> ApplyIncludes(IQueryable<Group> query) => query
        .Include(g => g.GroupRoles);
}

public sealed class RoleRepository : EfRepository<Role>, IRoleRepository
{
    public RoleRepository(KitDbContext context, IClock clock)
        : base(context, clock)
    {
    }

    protected override IQueryable<Role> ApplyIncludes(IQueryable<Role> query) => query
        .Include(r => r.Permissions)
        .Include(r => r.Policies);
}