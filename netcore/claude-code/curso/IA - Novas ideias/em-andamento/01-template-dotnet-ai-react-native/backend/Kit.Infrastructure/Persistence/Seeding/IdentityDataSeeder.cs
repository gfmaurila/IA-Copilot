using Kit.Application.Abstractions.Security;
using Kit.Domain.Common;
using Kit.Domain.Modules.Identity;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Kit.Infrastructure.Persistence.Seeding;

/// <summary>
/// Deterministic seed of the IAM module.
///
/// Guarantees:
///  - IDEMPOTENT: every write is guarded by an existence check, so restarting the
///    API never duplicates a role or a permission;
///  - DETERMINISTIC: no Guid or DateTime randomness. Demo/Stress data is
///    reproducible from a fixed seed, which is what makes a failing test debuggable;
///  - NO INVENTED BUSINESS DATA in Minimal mode: only what is needed to log in.
/// </summary>
public static class IdentityDataSeeder
{
    public static async Task SeedAsync(
        KitDbContext context,
        IPasswordHasher passwordHasher,
        string demoPassword,
        CancellationToken cancellationToken = default)
    {
        // ------------------------------------------------------------------
        // 1. Permission catalog (source of truth: Kit.Domain Permissions.All)
        // ------------------------------------------------------------------
        var existingPermissions = await context.Permissions
            .IgnoreQueryFilters()
            .Select(p => p.Name)
            .ToListAsync(cancellationToken);

        var existingSet = existingPermissions.ToHashSet(StringComparer.Ordinal);
        var permissionsByName = await context.Permissions
            .IgnoreQueryFilters()
            .ToDictionaryAsync(p => p.Name, StringComparer.Ordinal, cancellationToken);

        foreach (var definition in Permissions.All)
        {
            if (existingSet.Contains(definition.Name))
            {
                continue;
            }

            var created = Permission.Create(
                definition.Name,
                definition.Resource,
                definition.Action,
                definition.Description,
                isSystem: true);

            if (created.IsSuccess)
            {
                context.Permissions.Add(created.Value);
                permissionsByName[definition.Name] = created.Value;
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        // ------------------------------------------------------------------
        // 2. System roles + their permission matrix
        // ------------------------------------------------------------------
        var rolesByName = await context.Roles
            .Include(r => r.Permissions)
            .ToDictionaryAsync(r => r.Name, StringComparer.Ordinal, cancellationToken);

        foreach (var (roleName, permissionNames) in RolePermissionMatrix.All)
        {
            if (rolesByName.ContainsKey(roleName))
            {
                continue;
            }

            var rolePermissions = permissionNames
                .Where(permissionsByName.ContainsKey)
                .Select(name => permissionsByName[name])
                .ToList();

            var roleResult = Role.CreateSystem(
                roleName,
                RolePermissionMatrix.Descriptions.GetValueOrDefault(roleName, roleName),
                rolePermissions);

            if (roleResult.IsSuccess)
            {
                context.Roles.Add(roleResult.Value);
                rolesByName[roleName] = roleResult.Value;
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        // ------------------------------------------------------------------
        // 3. Default Organization
        // ------------------------------------------------------------------
        var organization = await context.Organizations.FirstOrDefaultAsync(o => o.Slug == "kit", cancellationToken);

        if (organization is null)
        {
            var organizationResult = Organization.Create(
                "Kit Platform",
                "kit",
                "Organizacao padrao criada pelo seeder.");

            if (organizationResult.IsSuccess)
            {
                organization = organizationResult.Value;
                organization.MarkAsDefault();
                context.Organizations.Add(organization);
                await context.SaveChangesAsync(cancellationToken);
            }
        }

        // ------------------------------------------------------------------
        // 4. Groups + their default role
        // ------------------------------------------------------------------
        var groupsByName = await context.Groups
            .Include(g => g.GroupRoles)
            .ToDictionaryAsync(g => g.Name, StringComparer.Ordinal, cancellationToken);

        foreach (var groupName in WellKnownGroups.All)
        {
            if (groupsByName.ContainsKey(groupName))
            {
                continue;
            }

            var groupResult = Group.Create(groupName, $"Grupo pre-configurado: {groupName}");

            if (groupResult.IsFailure)
            {
                continue;
            }

            var group = groupResult.Value;

            if (RolePermissionMatrix.GroupRoleMapping.TryGetValue(groupName, out var roleName)
                && rolesByName.TryGetValue(roleName, out var role))
            {
                group.AddSeededRole(role.Id);
            }

            context.Groups.Add(group);
            groupsByName[groupName] = group;
        }

        await context.SaveChangesAsync(cancellationToken);

        // ------------------------------------------------------------------
        // 5. Admin user (the only account Minimal mode creates)
        // ------------------------------------------------------------------
        const string adminEmail = "admin@kit.local";

        var adminExists = await context.Users.AnyAsync(u => u.Email.Value == adminEmail, cancellationToken);

        if (!adminExists)
        {
            var adminResult = User.CreateSeeded(
                organization!.Id,
                "Administrador",
                "Kit",
                adminEmail,
                passwordHasher.Hash(demoPassword),
                jobTitle: "Platform Owner");

            if (adminResult.IsSuccess)
            {
                var admin = adminResult.Value;
                admin.AddSeededRole(rolesByName[WellKnownRoles.SuperAdmin].Id);
                admin.AddSeededGroup(groupsByName[WellKnownGroups.Administrators].Id);
                context.Users.Add(admin);
                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}