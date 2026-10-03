using Kit.Domain.Modules.Ai;
using Kit.Domain.Modules.Audit;
using Kit.Domain.Modules.Content;
using Kit.Domain.Modules.Identity;
using Kit.Domain.Modules.Media;
using Kit.Domain.Modules.Navigation;
using Kit.Domain.Modules.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kit.Infrastructure.Persistence.Context;

/// <summary>
/// Single DbContext for the Modular Monolith.
/// One context, one transaction, one Unit of Work. Modules are separated by
/// aggregate boundaries and folder namespaces, not by separate databases.
/// </summary>
public sealed class KitDbContext : DbContext
{
    public KitDbContext(DbContextOptions<KitDbContext> options)
        : base(options)
    {
    }

    // Identity / IAM
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<GroupRole> GroupRoles => Set<GroupRole>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<UserGroup> UserGroups => Set<UserGroup>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<Policy> Policies => Set<Policy>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();

    // Content
    public DbSet<ContentType> ContentTypes => Set<ContentType>();
    public DbSet<Field> ContentFields => Set<Field>();
    public DbSet<ContentItem> ContentItems => Set<ContentItem>();
    public DbSet<ContentVersion> ContentVersions => Set<ContentVersion>();
    public DbSet<Taxonomy> Taxonomies => Set<Taxonomy>();

    // Media
    public DbSet<MediaItem> MediaItems => Set<MediaItem>();

    // Navigation
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();

    // Notifications
    public DbSet<Notification> Notifications => Set<Notification>();

    // Audit
    public DbSet<AuditEntry> AuditEntries => Set<AuditEntry>();

    // AI
    public DbSet<AiAgent> AiAgents => Set<AiAgent>();
    public DbSet<AiToolDefinition> AiTools => Set<AiToolDefinition>();
    public DbSet<AiPrompt> AiPrompts => Set<AiPrompt>();
    public DbSet<AgentExecution> AgentExecutions => Set<AgentExecution>();
    public DbSet<ApprovalRequest> ApprovalRequests => Set<ApprovalRequest>();
    public DbSet<AiRun> AiRuns => Set<AiRun>();
    public DbSet<KnowledgeBase> KnowledgeBases => Set<KnowledgeBase>();
    public DbSet<KnowledgeDocument> KnowledgeDocuments => Set<KnowledgeDocument>();
    public DbSet<DocumentChunk> DocumentChunks => Set<DocumentChunk>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KitDbContext).Assembly);

        // Global conventions: every table is prefixed with the module name so the
        // schema stays readable once Content/Media/AI are all present.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName is not null && !tableName.Contains('.', StringComparison.Ordinal))
            {
                entityType.SetTableName(tableName.ToLowerInvariant());
            }
        }
    }
}

/// <summary>
/// Convenience helpers used by EF configurations.
/// </summary>
internal static class ModelBuilderExtensions
{
    /// <summary>
    /// Maps the base Entity contract: Guid PK, audit timestamps and the optimistic
    /// concurrency token. The concurrency token is written through its backing
    /// field because it is intentionally read-only from the outside.
    /// </summary>
    public static EntityTypeBuilder<TEntity> ConfigureBaseEntity<TEntity>(
        this EntityTypeBuilder<TEntity> builder)
        where TEntity : class
    {
        builder.HasKey("Id");
        builder.Property("Id").ValueGeneratedNever();

        builder.Property<DateTime>("CreatedAt").IsRequired();
        builder.Property<DateTime?>("UpdatedAt");

        builder.Property<long>("Version")
            .IsConcurrencyToken()
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        return builder;
    }
}