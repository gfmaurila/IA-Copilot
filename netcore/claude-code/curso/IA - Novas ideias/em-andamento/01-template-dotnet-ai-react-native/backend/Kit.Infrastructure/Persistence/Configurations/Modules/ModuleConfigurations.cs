using Kit.Domain.Modules.Ai;
using Kit.Domain.Modules.Audit;
using Kit.Domain.Modules.Content;
using Kit.Domain.Modules.Media;
using Kit.Domain.Modules.Navigation;
using Kit.Domain.Modules.Notifications;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Kit.Infrastructure.Persistence.Configurations.Modules;

public sealed class ContentTypeConfiguration : IEntityTypeConfiguration<ContentType>
{
    public void Configure(EntityTypeBuilder<ContentType> builder)
    {
        builder.ToTable("cnt_content_types");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.IsSystem).IsRequired();

        builder.HasIndex(x => new { x.OrganizationId, x.Slug }).IsUnique();

        builder.HasMany(x => x.Fields)
            .WithOne()
            .HasForeignKey("ContentTypeId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Fields).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class ContentFieldConfiguration : IEntityTypeConfiguration<Field>
{
    public void Configure(EntityTypeBuilder<Field> builder)
    {
        builder.ToTable("cnt_fields");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.ContentTypeId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.IsRequired).IsRequired();
        builder.Property(x => x.Position).IsRequired();
        builder.Property(x => x.OptionsJson).HasColumnType("json");

        builder.HasIndex(x => x.ContentTypeId);
    }
}

public sealed class ContentItemConfiguration : IEntityTypeConfiguration<ContentItem>
{
    public void Configure(EntityTypeBuilder<ContentItem> builder)
    {
        builder.ToTable("cnt_content_items");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.ContentTypeId).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();
        builder.Property(x => x.Summary).HasMaxLength(1000);
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.PayloadJson).HasColumnType("json").IsRequired();

        builder.HasIndex(x => new { x.ContentTypeId, x.Slug }).IsUnique();
        builder.HasIndex(x => new { x.OrganizationId, x.Status });

        builder.HasMany(x => x.Versions)
            .WithOne()
            .HasForeignKey("ContentItemId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Versions).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class ContentVersionConfiguration : IEntityTypeConfiguration<ContentVersion>
{
    public void Configure(EntityTypeBuilder<ContentVersion> builder)
    {
        builder.ToTable("cnt_content_versions");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.ContentItemId).IsRequired();
        builder.Property(x => x.VersionNumber).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
        builder.Property(x => x.PayloadJson).HasColumnType("json").IsRequired();

        builder.HasIndex(x => new { x.ContentItemId, x.VersionNumber }).IsUnique();
    }
}

public sealed class TaxonomyConfiguration : IEntityTypeConfiguration<Taxonomy>
{
    public void Configure(EntityTypeBuilder<Taxonomy> builder)
    {
        builder.ToTable("cnt_taxonomies");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
        builder.Property(x => x.IsHierarchical).IsRequired();
        builder.Ignore(x => x.Terms);

        builder.HasIndex(x => x.Slug).IsUnique();
    }
}

public sealed class MediaItemConfiguration : IEntityTypeConfiguration<MediaItem>
{
    public void Configure(EntityTypeBuilder<MediaItem> builder)
    {
        builder.ToTable("med_media_items");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.FileName).HasMaxLength(400).IsRequired();
        builder.Property(x => x.StorageKey).HasMaxLength(500).IsRequired();
        builder.Property(x => x.ContentType).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Kind).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.AltText).HasMaxLength(500);
        builder.Property(x => x.UploadedByUserId).IsRequired();

        builder.HasIndex(x => x.StorageKey).IsUnique();
        builder.HasIndex(x => new { x.OrganizationId, x.Status });
    }
}

public sealed class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("nav_menus");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Location).HasConversion<string>().HasMaxLength(32).IsRequired();

        builder.HasIndex(x => new { x.Name, x.Location }).IsUnique();

        builder.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey("MenuId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("nav_menu_items");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.MenuId).IsRequired();
        builder.Property(x => x.Label).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Url).HasMaxLength(500);
        builder.Property(x => x.Order).IsRequired();
        builder.Property(x => x.IsVisible).IsRequired();

        builder.Ignore(x => x.IsExternal);

        builder.HasIndex(x => new { x.MenuId, x.ParentId, x.Order });
    }
}

public sealed class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("ntf_notifications");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Channel).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
        builder.Property(x => x.Body).HasMaxLength(4000).IsRequired();
        builder.Property(x => x.ActionUrl).HasMaxLength(500);
        builder.Property(x => x.FailureReason).HasMaxLength(500);

        builder.HasIndex(x => new { x.RecipientUserId, x.Status });
    }
}

public sealed class AuditEntryConfiguration : IEntityTypeConfiguration<AuditEntry>
{
    public void Configure(EntityTypeBuilder<AuditEntry> builder)
    {
        builder.ToTable("adt_audit_entries");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Module).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Resource).HasMaxLength(160).IsRequired();
        builder.Property(x => x.ResourceId).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Action).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.Outcome).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.ActorEmail).HasMaxLength(320);
        builder.Property(x => x.CorrelationId).HasMaxLength(80);
        builder.Property(x => x.IpAddress).HasMaxLength(64);
        builder.Property(x => x.DetailsJson).HasColumnType("json").IsRequired();

        builder.HasIndex(x => new { x.OrganizationId, x.OccurredAtUtc });
        builder.HasIndex(x => new { x.Resource, x.ResourceId });
        builder.HasIndex(x => x.ActorId);
    }
}

public sealed class AiAgentConfiguration : IEntityTypeConfiguration<AiAgent>
{
    public void Configure(EntityTypeBuilder<AiAgent> builder)
    {
        builder.ToTable("ai_agents");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.ModelSettingsJson).HasColumnType("json").IsRequired();
        builder.Property(x => x.RequiresHumanApproval).IsRequired();

        // Tool and prompt allowlists are persisted as JSON columns so the agent
        // can never reference a tool that is not explicitly registered, and a
        // single round trip loads the whole allowlist.
        builder.Property(x => x.ToolNames)
            .HasConversion(
                v => JsonSerializer.Serialize(v, JsonOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonOptions) ?? new List<string>())
            .HasColumnType("json")
            .IsRequired();

        builder.Property(x => x.PromptNames)
            .HasConversion(
                v => JsonSerializer.Serialize(v, JsonOptions),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonOptions) ?? new List<string>())
            .HasColumnType("json")
            .IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
    }

    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
}

public sealed class AiToolDefinitionConfiguration : IEntityTypeConfiguration<AiToolDefinition>
{
    public void Configure(EntityTypeBuilder<AiToolDefinition> builder)
    {
        builder.ToTable("ai_tools");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
        builder.Property(x => x.RequiredPermission).HasMaxLength(160).IsRequired();
        builder.Property(x => x.InputSchemaJson).HasColumnType("json").IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.IsReadOnly).IsRequired();
        builder.Property(x => x.RequiresApproval).IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.RequiredPermission);
    }
}

public sealed class AiPromptConfiguration : IEntityTypeConfiguration<AiPrompt>
{
    public void Configure(EntityTypeBuilder<AiPrompt> builder)
    {
        builder.ToTable("ai_prompts");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Template).HasColumnType("text").IsRequired();
        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.TemplateVersion).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();

        builder.HasIndex(x => new { x.Name, x.TemplateVersion }).IsUnique();
    }
}

public sealed class AgentExecutionConfiguration : IEntityTypeConfiguration<AgentExecution>
{
    public void Configure(EntityTypeBuilder<AgentExecution> builder)
    {
        builder.ToTable("ai_executions");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.AgentId).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.CorrelationId).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.InputJson).HasColumnType("json");
        builder.Property(x => x.OutputJson).HasColumnType("json");
        builder.Property(x => x.ErrorMessage).HasMaxLength(2000);
        builder.Property(x => x.RequiresHumanApproval).IsRequired();
        builder.Property(x => x.RetryCount).IsRequired();
        builder.Property(x => x.EstimatedCostUsd).HasPrecision(12, 6);
        builder.Property(x => x.PromptTokens).IsRequired();
        builder.Property(x => x.CompletionTokens).IsRequired();

        builder.HasIndex(x => new { x.AgentId, x.Status });
        builder.HasIndex(x => x.CorrelationId);

        builder.HasMany(x => x.Approvals)
            .WithOne()
            .HasForeignKey("ExecutionId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Approvals).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class ApprovalRequestConfiguration : IEntityTypeConfiguration<ApprovalRequest>
{
    public void Configure(EntityTypeBuilder<ApprovalRequest> builder)
    {
        builder.ToTable("ai_approvals");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.ExecutionId).IsRequired();
        builder.Property(x => x.ActionName).HasMaxLength(200).IsRequired();
        builder.Property(x => x.PayloadJson).HasColumnType("json").IsRequired();
        builder.Property(x => x.RequestedByTool).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.ReviewerComment).HasMaxLength(1000);

        builder.HasIndex(x => new { x.Status, x.ExpiresAtUtc });
        builder.HasIndex(x => x.ExecutionId);
    }
}

public sealed class AiRunConfiguration : IEntityTypeConfiguration<AiRun>
{
    public void Configure(EntityTypeBuilder<AiRun> builder)
    {
        builder.ToTable("ai_runs");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Provider).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Model).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Operation).HasMaxLength(40).IsRequired();
        builder.Property(x => x.CorrelationId).HasMaxLength(80).IsRequired();
        builder.Property(x => x.ErrorMessage).HasMaxLength(2000);
        builder.Property(x => x.ToolName).HasMaxLength(160);
        builder.Property(x => x.Success).IsRequired();
        builder.Property(x => x.Attempt).IsRequired();
        builder.Property(x => x.EstimatedCostUsd).HasPrecision(12, 6);

        builder.HasIndex(x => new { x.Provider, x.Model });
        builder.HasIndex(x => x.CorrelationId);
        builder.HasIndex(x => x.StartedAtUtc);
    }
}

public sealed class KnowledgeBaseConfiguration : IEntityTypeConfiguration<KnowledgeBase>
{
    public void Configure(EntityTypeBuilder<KnowledgeBase> builder)
    {
        builder.ToTable("ai_knowledge_bases");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
        builder.Property(x => x.EmbeddingModel).HasMaxLength(160).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();

        // Scope enforcement: every query against this aggregate must filter on
        // OrganizationId. The composite index supports that filter.
        builder.HasIndex(x => new { x.OrganizationId, x.Status });

        builder.HasMany(x => x.Documents)
            .WithOne()
            .HasForeignKey("KnowledgeBaseId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Documents).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class KnowledgeDocumentConfiguration : IEntityTypeConfiguration<KnowledgeDocument>
{
    public void Configure(EntityTypeBuilder<KnowledgeDocument> builder)
    {
        builder.ToTable("ai_knowledge_documents");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.KnowledgeBaseId).IsRequired();
        builder.Property(x => x.FileName).HasMaxLength(400).IsRequired();
        builder.Property(x => x.ContentType).HasMaxLength(160).IsRequired();
        builder.Property(x => x.StorageKey).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        builder.Property(x => x.ErrorMessage).HasMaxLength(2000);
        builder.Property(x => x.UploadedByUserId).IsRequired();
        builder.Property(x => x.ChunkCount).IsRequired();

        builder.HasIndex(x => new { x.KnowledgeBaseId, x.Status });

        builder.HasMany(x => x.Chunks)
            .WithOne()
            .HasForeignKey("DocumentId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Chunks).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}

public sealed class DocumentChunkConfiguration : IEntityTypeConfiguration<DocumentChunk>
{
    public void Configure(EntityTypeBuilder<DocumentChunk> builder)
    {
        builder.ToTable("ai_document_chunks");
        builder.ConfigureBaseEntity();

        builder.Property(x => x.DocumentId).IsRequired();
        builder.Property(x => x.Position).IsRequired();
        builder.Property(x => x.Text).HasColumnType("text").IsRequired();
        builder.Property(x => x.VectorPointId).HasMaxLength(160);
        builder.Property(x => x.TokenCount).IsRequired();

        builder.HasIndex(x => new { x.DocumentId, x.Position }).IsUnique();
        builder.HasIndex(x => x.VectorPointId);
    }
}