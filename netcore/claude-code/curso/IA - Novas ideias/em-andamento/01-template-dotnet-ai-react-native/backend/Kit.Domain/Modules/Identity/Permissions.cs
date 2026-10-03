using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

/// <summary>
/// Canonical permission catalog. Permissions are granular strings in
/// "&lt;resource&gt;.&lt;action&gt;" form and are the ONLY authorization currency
/// in the platform. The API is the final authority; the frontend may hide actions
/// but can never grant them.
/// </summary>
public static class Permissions
{
    public const string UsersRead = "users.read";
    public const string UsersCreate = "users.create";
    public const string UsersUpdate = "users.update";
    public const string UsersDelete = "users.delete";
    public const string UsersBlock = "users.block";

    public const string RolesRead = "roles.read";
    public const string RolesCreate = "roles.create";
    public const string RolesUpdate = "roles.update";
    public const string RolesDelete = "roles.delete";

    public const string PermissionsRead = "permissions.read";
    public const string PermissionsAssign = "permissions.assign";

    public const string ContentRead = "content.read";
    public const string ContentCreate = "content.create";
    public const string ContentUpdate = "content.update";
    public const string ContentDelete = "content.delete";
    public const string ContentPublish = "content.publish";

    public const string MediaRead = "media.read";
    public const string MediaUpload = "media.upload";
    public const string MediaDelete = "media.delete";

    public const string AiChatUse = "ai.chat.use";
    public const string AiAgentsRead = "ai.agents.read";
    public const string AiAgentsExecute = "ai.agents.execute";
    public const string AiAgentsManage = "ai.agents.manage";
    public const string AiToolsExecute = "ai.tools.execute";
    public const string AiToolsManage = "ai.tools.manage";
    public const string AiKnowledgeRead = "ai.knowledge.read";
    public const string AiKnowledgeManage = "ai.knowledge.manage";

    public const string AuditRead = "audit.read";
    public const string SettingsRead = "settings.read";
    public const string SettingsManage = "settings.manage";

    public const string NavigationRead = "navigation.read";
    public const string NavigationManage = "navigation.manage";
    public const string NotificationsRead = "notifications.read";
    public const string OrganizationsRead = "organizations.read";
    public const string OrganizationsManage = "organizations.manage";

    public static IReadOnlyList<PermissionDefinition> All { get; } =
    [
        new(UsersRead, "users", "read", "Listar e consultar usuários"),
        new(UsersCreate, "users", "create", "Criar usuários"),
        new(UsersUpdate, "users", "update", "Atualizar usuários"),
        new(UsersDelete, "users", "delete", "Excluir usuários"),
        new(UsersBlock, "users", "block", "Bloquear e desbloquear usuários"),
        new(RolesRead, "roles", "read", "Listar e consultar roles"),
        new(RolesCreate, "roles", "create", "Criar roles"),
        new(RolesUpdate, "roles", "update", "Atualizar roles"),
        new(RolesDelete, "roles", "delete", "Excluir roles"),
        new(PermissionsRead, "permissions", "read", "Listar permissões"),
        new(PermissionsAssign, "permissions", "assign", "Conceder e revogar permissões"),
        new(ContentRead, "content", "read", "Ler conteúdo"),
        new(ContentCreate, "content", "create", "Criar conteúdo"),
        new(ContentUpdate, "content", "update", "Atualizar conteúdo"),
        new(ContentDelete, "content", "delete", "Excluir conteúdo"),
        new(ContentPublish, "content", "publish", "Publicar conteúdo"),
        new(MediaRead, "media", "read", "Ler metadados de mídia"),
        new(MediaUpload, "media", "upload", "Enviar arquivos de mídia"),
        new(MediaDelete, "media", "delete", "Excluir arquivos de mídia"),
        new(AiChatUse, "ai.chat", "use", "Utilizar o chat de IA"),
        new(AiAgentsRead, "ai.agents", "read", "Consultar agentes de IA"),
        new(AiAgentsExecute, "ai.agents", "execute", "Executar agentes de IA"),
        new(AiAgentsManage, "ai.agents", "manage", "Criar, editar e excluir agentes"),
        new(AiToolsExecute, "ai.tools", "execute", "Executar tools de IA"),
        new(AiToolsManage, "ai.tools", "manage", "Criar, editar e excluir tools"),
        new(AiKnowledgeRead, "ai.knowledge", "read", "Consultar bases de conhecimento"),
        new(AiKnowledgeManage, "ai.knowledge", "manage", "Gerenciar bases de conhecimento"),
        new(AuditRead, "audit", "read", "Consultar trilha de auditoria"),
        new(SettingsRead, "settings", "read", "Consultar configurações"),
        new(SettingsManage, "settings", "manage", "Gerenciar configurações"),
        new(NavigationRead, "navigation", "read", "Consultar navegação"),
        new(NavigationManage, "navigation", "manage", "Gerenciar navegação"),
        new(NotificationsRead, "notifications", "read", "Consultar notificações"),
        new(OrganizationsRead, "organizations", "read", "Consultar organizações"),
        new(OrganizationsManage, "organizations", "manage", "Gerenciar organizações")
    ];

    public static bool Exists(string permission) => All.Any(p => p.Name == permission);
}

public sealed record PermissionDefinition(string Name, string Resource, string Action, string Description);

public static class WellKnownRoles
{
    public const string SuperAdmin = "SuperAdmin";
    public const string Administrator = "Administrator";
    public const string UserManager = "UserManager";
    public const string ContentManager = "ContentManager";
    public const string Editor = "Editor";
    public const string Viewer = "Viewer";
    public const string AiManager = "AIManager";
    public const string AiOperator = "AIOperator";
    public const string User = "User";

    public static IReadOnlyList<string> All { get; } =
    [
        SuperAdmin, Administrator, UserManager, ContentManager, Editor, Viewer, AiManager, AiOperator, User
    ];
}

public static class WellKnownGroups
{
    public const string Administrators = "Administrators";
    public const string Developers = "Developers";
    public const string Marketing = "Marketing";
    public const string ContentTeam = "Content Team";
    public const string Support = "Support";
    public const string Finance = "Finance";
    public const string Guests = "Guests";

    public static IReadOnlyList<string> All { get; } =
    [
        Administrators, Developers, Marketing, ContentTeam, Support, Finance, Guests
    ];
}