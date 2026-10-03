using Kit.Domain.Modules.Identity;

namespace Kit.Infrastructure.Persistence.Seeding;

/// <summary>
/// The role/permission matrix of the IAM module.
///
/// It is written ONCE here and consumed by every seed mode, so Minimal, Demo and
/// Stress can never disagree about what a role is allowed to do. Roles are seeded
/// in code, not in configuration: a security decision must be reviewable in a pull
/// request, not editable by whoever has access to appsettings.
/// </summary>
public static class RolePermissionMatrix
{
    public static IReadOnlyList<(string Role, string[] Permissions)> All { get; } =
    [
        (WellKnownRoles.SuperAdmin, [.. Permissions.All.Select(p => p.Name)]),

        (WellKnownRoles.Administrator,
        [
            Permissions.UsersRead, Permissions.UsersCreate, Permissions.UsersUpdate, Permissions.UsersBlock,
            Permissions.RolesRead, Permissions.RolesCreate, Permissions.RolesUpdate,
            Permissions.PermissionsRead, Permissions.PermissionsAssign,
            Permissions.ContentRead, Permissions.ContentCreate, Permissions.ContentUpdate,
            Permissions.MediaRead, Permissions.MediaUpload,
            Permissions.AuditRead, Permissions.SettingsRead,
            Permissions.NavigationRead, Permissions.NavigationManage,
            Permissions.NotificationsRead,
            Permissions.OrganizationsRead, Permissions.OrganizationsManage,
            Permissions.AiChatUse, Permissions.AiAgentsRead
        ]),

        (WellKnownRoles.UserManager,
        [
            Permissions.UsersRead, Permissions.UsersCreate, Permissions.UsersUpdate, Permissions.UsersDelete,
            Permissions.UsersBlock, Permissions.RolesRead, Permissions.PermissionsRead,
            Permissions.NotificationsRead, Permissions.AuditRead
        ]),

        (WellKnownRoles.ContentManager,
        [
            Permissions.ContentRead, Permissions.ContentCreate, Permissions.ContentUpdate,
            Permissions.ContentDelete, Permissions.ContentPublish,
            Permissions.MediaRead, Permissions.MediaUpload, Permissions.MediaDelete,
            Permissions.NavigationRead, Permissions.NavigationManage
        ]),

        (WellKnownRoles.Editor,
        [
            Permissions.ContentRead, Permissions.ContentCreate, Permissions.ContentUpdate,
            Permissions.MediaRead, Permissions.MediaUpload, Permissions.NavigationRead
        ]),

        (WellKnownRoles.Viewer,
        [
            Permissions.ContentRead, Permissions.MediaRead, Permissions.NavigationRead,
            Permissions.NotificationsRead
        ]),

        (WellKnownRoles.AiManager,
        [
            Permissions.AiChatUse, Permissions.AiAgentsRead, Permissions.AiAgentsExecute,
            Permissions.AiAgentsManage, Permissions.AiToolsExecute, Permissions.AiToolsManage,
            Permissions.AiKnowledgeRead, Permissions.AiKnowledgeManage,
            Permissions.ContentRead
        ]),

        (WellKnownRoles.AiOperator,
        [
            Permissions.AiChatUse, Permissions.AiAgentsRead, Permissions.AiAgentsExecute,
            Permissions.AiToolsExecute, Permissions.AiKnowledgeRead, Permissions.ContentRead
        ]),

        (WellKnownRoles.User,
        [
            Permissions.NotificationsRead, Permissions.NavigationRead
        ])
    ];

    public static IReadOnlyDictionary<string, string> Descriptions { get; } =
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            [WellKnownRoles.SuperAdmin] = "Acesso total. Exclusivo de emergência e de operação controlada.",
            [WellKnownRoles.Administrator] = "Administração do ambiente sem poder de apagar usuários nem gerenciar IA.",
            [WellKnownRoles.UserManager] = "Ciclo de vida de usuários, papéis e permissões.",
            [WellKnownRoles.ContentManager] = "Autoria, publicação e mídia.",
            [WellKnownRoles.Editor] = "Autoria de conteúdo sem publicação.",
            [WellKnownRoles.Viewer] = "Somente leitura.",
            [WellKnownRoles.AiManager] = "Configuração de agentes, tools e bases de conhecimento.",
            [WellKnownRoles.AiOperator] = "Execução de agentes e tools já configurados.",
            [WellKnownRoles.User] = "Usuário autenticado sem privilégios adicionais."
        };

    public static IReadOnlyDictionary<string, string> GroupRoleMapping { get; } =
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            [WellKnownGroups.Administrators] = WellKnownRoles.Administrator,
            [WellKnownGroups.Developers] = WellKnownRoles.Editor,
            [WellKnownGroups.Marketing] = WellKnownRoles.Editor,
            [WellKnownGroups.ContentTeam] = WellKnownRoles.ContentManager,
            [WellKnownGroups.Support] = WellKnownRoles.Viewer,
            [WellKnownGroups.Finance] = WellKnownRoles.Viewer,
            [WellKnownGroups.Guests] = WellKnownRoles.User
        };
}