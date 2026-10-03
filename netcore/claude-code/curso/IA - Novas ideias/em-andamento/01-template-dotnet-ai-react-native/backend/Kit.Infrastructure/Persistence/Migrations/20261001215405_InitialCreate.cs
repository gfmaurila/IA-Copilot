using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kit.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "adt_audit_entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Module = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Resource = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    ResourceId = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Action = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Outcome = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    ActorId = table.Column<Guid>(type: "char(36)", nullable: true),
                    ActorEmail = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: true),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CorrelationId = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    IpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    DetailsJson = table.Column<string>(type: "json", nullable: false),
                    OccurredAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adt_audit_entries", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    ModelSettingsJson = table.Column<string>(type: "json", nullable: false),
                    ToolNames = table.Column<string>(type: "json", nullable: false),
                    PromptNames = table.Column<string>(type: "json", nullable: false),
                    RequiresHumanApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_agents", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_executions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AgentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CorrelationId = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    InputJson = table.Column<string>(type: "json", nullable: true),
                    OutputJson = table.Column<string>(type: "json", nullable: true),
                    ErrorMessage = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    RequiresHumanApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StartedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompletedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RetryCount = table.Column<int>(type: "int", nullable: false),
                    EstimatedCostUsd = table.Column<decimal>(type: "decimal(12,6)", precision: 12, scale: 6, nullable: false),
                    PromptTokens = table.Column<int>(type: "int", nullable: false),
                    CompletionTokens = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_executions", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_knowledge_bases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    EmbeddingModel = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_knowledge_bases", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_prompts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Template = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    TemplateVersion = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_prompts", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_runs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Provider = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Model = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Operation = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    ExecutionId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CorrelationId = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    PromptTokens = table.Column<int>(type: "int", nullable: false),
                    CompletionTokens = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    EstimatedCostUsd = table.Column<decimal>(type: "decimal(12,6)", precision: 12, scale: 6, nullable: false),
                    Success = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    StartedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Attempt = table.Column<int>(type: "int", nullable: false),
                    ToolName = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_runs", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_tools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    RequiredPermission = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    IsReadOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InputSchemaJson = table.Column<string>(type: "json", nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    RequiresApproval = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_tools", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_content_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContentTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Slug = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Summary = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    TaxonomyId = table.Column<Guid>(type: "char(36)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    PayloadJson = table.Column<string>(type: "json", nullable: false),
                    PublishedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PublishedByUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_content_items", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_content_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    IsSystem = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_content_types", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_taxonomies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    IsHierarchical = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_taxonomies", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_api_keys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Prefix = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false),
                    KeyHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUsedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RevokedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_api_keys", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    ParentGroupId = table.Column<string>(type: "longtext", nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_groups", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_organizations", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Kind = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    IsSystem = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeletable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    email = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    JobTitle = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    AvatarUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MustChangePassword = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "med_media_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FileName = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    StorageKey = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    ContentType = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    Kind = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    UploadedByUserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: true),
                    AltText = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    UploadedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_med_media_items", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nav_menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nav_menus", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ntf_notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RecipientUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Channel = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Body = table.Column<string>(type: "varchar(4000)", maxLength: 4000, nullable: false),
                    ActionUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SentAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ReadAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FailureReason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ntf_notifications", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_approvals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ExecutionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ActionName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PayloadJson = table.Column<string>(type: "json", nullable: false),
                    RequestedByTool = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    ReviewerUserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    ReviewerComment = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    RequestedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DecidedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ai_approvals_ai_executions_ExecutionId",
                        column: x => x.ExecutionId,
                        principalTable: "ai_executions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_knowledge_documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    KnowledgeBaseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FileName = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    ContentType = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    StorageKey = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    UploadedByUserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    ErrorMessage = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    ChunkCount = table.Column<int>(type: "int", nullable: false),
                    IngestedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_knowledge_documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ai_knowledge_documents_ai_knowledge_bases_KnowledgeBaseId",
                        column: x => x.KnowledgeBaseId,
                        principalTable: "ai_knowledge_bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_content_versions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContentItemId = table.Column<Guid>(type: "char(36)", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    PayloadJson = table.Column<string>(type: "json", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_content_versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cnt_content_versions_cnt_content_items_ContentItemId",
                        column: x => x.ContentItemId,
                        principalTable: "cnt_content_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cnt_fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContentTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Type = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    IsRequired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    OptionsJson = table.Column<string>(type: "json", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnt_fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cnt_fields_cnt_content_types_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "cnt_content_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_group_roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    GroupId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_group_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_group_roles_iam_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "iam_groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_teams_iam_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "iam_organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Resource = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Action = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    IsSystem = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_permissions_iam_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "iam_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_policies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Effect = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    ConditionsJson = table.Column<string>(type: "json", nullable: false),
                    IsSystem = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_policies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_policies_iam_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "iam_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TokenHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    IpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    UserAgent = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true),
                    StartedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    EndReason = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_sessions_iam_users_UserId",
                        column: x => x.UserId,
                        principalTable: "iam_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_user_groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    GroupId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_user_groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_user_groups_iam_users_UserId",
                        column: x => x.UserId,
                        principalTable: "iam_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_user_roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_user_roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_user_roles_iam_users_UserId",
                        column: x => x.UserId,
                        principalTable: "iam_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nav_menu_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    MenuId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Label = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    ContentItemId = table.Column<Guid>(type: "char(36)", nullable: true),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nav_menu_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nav_menu_items_nav_menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "nav_menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ai_document_chunks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DocumentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    VectorPointId = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    TokenCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ai_document_chunks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ai_document_chunks_ai_knowledge_documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "ai_knowledge_documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "iam_refresh_tokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SessionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    TokenHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RevokedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iam_refresh_tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_iam_refresh_tokens_iam_sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "iam_sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_adt_audit_entries_ActorId",
                table: "adt_audit_entries",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_adt_audit_entries_OrganizationId_OccurredAtUtc",
                table: "adt_audit_entries",
                columns: new[] { "OrganizationId", "OccurredAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_adt_audit_entries_Resource_ResourceId",
                table: "adt_audit_entries",
                columns: new[] { "Resource", "ResourceId" });

            migrationBuilder.CreateIndex(
                name: "IX_ai_agents_Name",
                table: "ai_agents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ai_approvals_ExecutionId",
                table: "ai_approvals",
                column: "ExecutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ai_approvals_Status_ExpiresAtUtc",
                table: "ai_approvals",
                columns: new[] { "Status", "ExpiresAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_ai_document_chunks_DocumentId_Position",
                table: "ai_document_chunks",
                columns: new[] { "DocumentId", "Position" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ai_document_chunks_VectorPointId",
                table: "ai_document_chunks",
                column: "VectorPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ai_executions_AgentId_Status",
                table: "ai_executions",
                columns: new[] { "AgentId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_ai_executions_CorrelationId",
                table: "ai_executions",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_ai_knowledge_bases_OrganizationId_Status",
                table: "ai_knowledge_bases",
                columns: new[] { "OrganizationId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_ai_knowledge_documents_KnowledgeBaseId_Status",
                table: "ai_knowledge_documents",
                columns: new[] { "KnowledgeBaseId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_ai_prompts_Name_TemplateVersion",
                table: "ai_prompts",
                columns: new[] { "Name", "TemplateVersion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ai_runs_CorrelationId",
                table: "ai_runs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_ai_runs_Provider_Model",
                table: "ai_runs",
                columns: new[] { "Provider", "Model" });

            migrationBuilder.CreateIndex(
                name: "IX_ai_runs_StartedAtUtc",
                table: "ai_runs",
                column: "StartedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ai_tools_Name",
                table: "ai_tools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ai_tools_RequiredPermission",
                table: "ai_tools",
                column: "RequiredPermission");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_content_items_ContentTypeId_Slug",
                table: "cnt_content_items",
                columns: new[] { "ContentTypeId", "Slug" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cnt_content_items_OrganizationId_Status",
                table: "cnt_content_items",
                columns: new[] { "OrganizationId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_cnt_content_types_OrganizationId_Slug",
                table: "cnt_content_types",
                columns: new[] { "OrganizationId", "Slug" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cnt_content_versions_ContentItemId_VersionNumber",
                table: "cnt_content_versions",
                columns: new[] { "ContentItemId", "VersionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cnt_fields_ContentTypeId",
                table: "cnt_fields",
                column: "ContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_cnt_taxonomies_Slug",
                table: "cnt_taxonomies",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_api_keys_Prefix",
                table: "iam_api_keys",
                column: "Prefix");

            migrationBuilder.CreateIndex(
                name: "IX_iam_api_keys_UserId",
                table: "iam_api_keys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_group_roles_GroupId_RoleId",
                table: "iam_group_roles",
                columns: new[] { "GroupId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_group_roles_RoleId",
                table: "iam_group_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_groups_Name",
                table: "iam_groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_organizations_Slug",
                table: "iam_organizations",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_organizations_Status",
                table: "iam_organizations",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_iam_permissions_Name",
                table: "iam_permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_permissions_RoleId",
                table: "iam_permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_policies_RoleId_Name",
                table: "iam_policies",
                columns: new[] { "RoleId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_refresh_tokens_SessionId",
                table: "iam_refresh_tokens",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_refresh_tokens_TokenHash",
                table: "iam_refresh_tokens",
                column: "TokenHash");

            migrationBuilder.CreateIndex(
                name: "IX_iam_roles_Name",
                table: "iam_roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_sessions_Status_ExpiresAtUtc",
                table: "iam_sessions",
                columns: new[] { "Status", "ExpiresAtUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_iam_sessions_UserId",
                table: "iam_sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_teams_OrganizationId_Name",
                table: "iam_teams",
                columns: new[] { "OrganizationId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_user_groups_GroupId",
                table: "iam_user_groups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_user_groups_UserId_GroupId",
                table: "iam_user_groups",
                columns: new[] { "UserId", "GroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_user_roles_RoleId",
                table: "iam_user_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_user_roles_UserId_RoleId",
                table: "iam_user_roles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_users_email",
                table: "iam_users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_iam_users_OrganizationId",
                table: "iam_users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_iam_users_Status",
                table: "iam_users",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_med_media_items_OrganizationId_Status",
                table: "med_media_items",
                columns: new[] { "OrganizationId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_med_media_items_StorageKey",
                table: "med_media_items",
                column: "StorageKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_nav_menu_items_MenuId_ParentId_Order",
                table: "nav_menu_items",
                columns: new[] { "MenuId", "ParentId", "Order" });

            migrationBuilder.CreateIndex(
                name: "IX_nav_menus_Name_Location",
                table: "nav_menus",
                columns: new[] { "Name", "Location" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ntf_notifications_RecipientUserId_Status",
                table: "ntf_notifications",
                columns: new[] { "RecipientUserId", "Status" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adt_audit_entries");

            migrationBuilder.DropTable(
                name: "ai_agents");

            migrationBuilder.DropTable(
                name: "ai_approvals");

            migrationBuilder.DropTable(
                name: "ai_document_chunks");

            migrationBuilder.DropTable(
                name: "ai_prompts");

            migrationBuilder.DropTable(
                name: "ai_runs");

            migrationBuilder.DropTable(
                name: "ai_tools");

            migrationBuilder.DropTable(
                name: "cnt_content_versions");

            migrationBuilder.DropTable(
                name: "cnt_fields");

            migrationBuilder.DropTable(
                name: "cnt_taxonomies");

            migrationBuilder.DropTable(
                name: "iam_api_keys");

            migrationBuilder.DropTable(
                name: "iam_group_roles");

            migrationBuilder.DropTable(
                name: "iam_permissions");

            migrationBuilder.DropTable(
                name: "iam_policies");

            migrationBuilder.DropTable(
                name: "iam_refresh_tokens");

            migrationBuilder.DropTable(
                name: "iam_teams");

            migrationBuilder.DropTable(
                name: "iam_user_groups");

            migrationBuilder.DropTable(
                name: "iam_user_roles");

            migrationBuilder.DropTable(
                name: "med_media_items");

            migrationBuilder.DropTable(
                name: "nav_menu_items");

            migrationBuilder.DropTable(
                name: "ntf_notifications");

            migrationBuilder.DropTable(
                name: "ai_executions");

            migrationBuilder.DropTable(
                name: "ai_knowledge_documents");

            migrationBuilder.DropTable(
                name: "cnt_content_items");

            migrationBuilder.DropTable(
                name: "cnt_content_types");

            migrationBuilder.DropTable(
                name: "iam_groups");

            migrationBuilder.DropTable(
                name: "iam_roles");

            migrationBuilder.DropTable(
                name: "iam_sessions");

            migrationBuilder.DropTable(
                name: "iam_organizations");

            migrationBuilder.DropTable(
                name: "nav_menus");

            migrationBuilder.DropTable(
                name: "ai_knowledge_bases");

            migrationBuilder.DropTable(
                name: "iam_users");
        }
    }
}
