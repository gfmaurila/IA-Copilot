using Kit.Domain.Modules.Identity;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kit.Infrastructure.Persistence.Configurations.Identity;

public sealed class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("iam_organizations");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.IsDefault).IsRequired();

        builder.HasIndex(x => x.Slug).IsUnique();
        builder.HasIndex(x => x.Status);

        builder.HasMany(x => x.Teams)
            .WithOne()
            .HasForeignKey("OrganizationId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Teams).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("iam_teams");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.Property(x => x.OrganizationId).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();

        builder.HasIndex(x => new { x.OrganizationId, x.Name }).IsUnique();
    }
}

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("iam_users");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.FirstName).HasMaxLength(120).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(120).IsRequired();
        builder.Property(x => x.JobTitle).HasMaxLength(200);
        builder.Property(x => x.AvatarUrl).HasMaxLength(500);
        builder.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();

        // Email is a Value Object: mapped to a single owned column so the
        // normalized value is stored once and can be indexed.
        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .HasMaxLength(320)
                .IsRequired()
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            // Uniqueness is enforced by the DATABASE, not only by the Application:
            // login resolves a user by e-mail, so a duplicate would make the
            // identity of the caller ambiguous.
            email.HasIndex(e => e.Value).HasDatabaseName("IX_iam_users_email").IsUnique();
        });

        builder.Navigation(x => x.Email).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.HasIndex(x => x.OrganizationId);
        builder.HasIndex(x => x.Status);

        builder.HasMany(x => x.Sessions)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.UserRoles)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.UserGroups)
            .WithOne()
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Sessions).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(x => x.UserRoles).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(x => x.UserGroups).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("iam_user_roles");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.RoleId).IsRequired();

        builder.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
        builder.HasIndex(x => x.RoleId);
    }
}

public sealed class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.ToTable("iam_user_groups");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.GroupId).IsRequired();

        builder.HasIndex(x => new { x.UserId, x.GroupId }).IsUnique();
        builder.HasIndex(x => x.GroupId);
    }
}

public sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("iam_groups");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasMany(x => x.GroupRoles)
            .WithOne()
            .HasForeignKey("GroupId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.GroupRoles).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole>
{
    public void Configure(EntityTypeBuilder<GroupRole> builder)
    {
        builder.ToTable("iam_group_roles");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.GroupId).IsRequired();
        builder.Property(x => x.RoleId).IsRequired();

        builder.HasIndex(x => new { x.GroupId, x.RoleId }).IsUnique();
        builder.HasIndex(x => x.RoleId);
    }
}

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("iam_roles");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Kind).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.IsSystem).IsRequired();
        builder.Property(x => x.IsDeletable).IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasMany(x => x.Permissions)
            .WithOne()
            .HasForeignKey("RoleId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Policies)
            .WithOne()
            .HasForeignKey("RoleId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Permissions).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(x => x.Policies).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("iam_permissions");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Resource).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Action).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
        builder.Property(x => x.IsSystem).IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
    }
}

public sealed class PolicyConfiguration : IEntityTypeConfiguration<Policy>
{
    public void Configure(EntityTypeBuilder<Policy> builder)
    {
        builder.ToTable("iam_policies");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.RoleId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Effect).HasMaxLength(16).IsRequired();
        builder.Property(x => x.ConditionsJson).HasColumnType("json").IsRequired();
        builder.Property(x => x.IsSystem).IsRequired();

        builder.HasIndex(x => new { x.RoleId, x.Name }).IsUnique();
    }
}

public sealed class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("iam_sessions");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.TokenHash).HasMaxLength(255).IsRequired();
        builder.Property(x => x.IpAddress).HasMaxLength(64);
        builder.Property(x => x.UserAgent).HasMaxLength(400);
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.EndReason).HasMaxLength(120);

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => new { x.Status, x.ExpiresAtUtc });

        builder.HasMany(x => x.RefreshTokens)
            .WithOne()
            .HasForeignKey("SessionId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.RefreshTokens).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("iam_refresh_tokens");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.SessionId).IsRequired();
        builder.Property(x => x.TokenHash).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();

        builder.HasIndex(x => x.SessionId);
        builder.HasIndex(x => x.TokenHash);
    }
}

public sealed class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.ToTable("iam_api_keys");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Prefix).HasMaxLength(24).IsRequired();
        builder.Property(x => x.KeyHash).HasMaxLength(255).IsRequired();

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.Prefix);
    }
}