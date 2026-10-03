using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

/// <summary>
/// Role is the container that maps to Permissions. A Role is either a plain
/// permission set (RoleKind.Permission) or a policy-driven role
/// (RoleKind.Policy), where the conditions live in <see cref="Policy"/>.
/// </summary>
public sealed class Role : AggregateRoot
{
    private readonly List<Permission> _permissions = [];
    private readonly List<Policy> _policies = [];

    private Role()
    {
    }

    private Role(Guid id, string name, string description, RoleKind kind, bool isSystem, bool isDeletable)
    {
        Id = id;
        Name = name;
        Description = description;
        Kind = kind;
        IsSystem = isSystem;
        IsDeletable = isDeletable;
    }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public RoleKind Kind { get; private set; }

    /// <summary>System roles are seeded and cannot be renamed or deleted.</summary>
    public bool IsSystem { get; private set; }

    public bool IsDeletable { get; private set; }

    public IReadOnlyCollection<Permission> Permissions => _permissions.AsReadOnly();

    public IReadOnlyCollection<Policy> Policies => _policies.AsReadOnly();

    public static Result<Role> Create(string name, string description, bool isSystem = false, bool isDeletable = true)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Role>(Error.Validation("role.name.required", "Nome da role é obrigatório."));
        }

        return Result.Success(new Role(Guid.NewGuid(), name.Trim(), description?.Trim() ?? string.Empty, RoleKind.Permission, isSystem, isDeletable));
    }

    public Result AttachPermission(Permission permission)
    {
        ArgumentNullException.ThrowIfNull(permission);

        if (_permissions.Any(p => p.Id == permission.Id))
        {
            return Result.Failure(Error.Conflict("role.permission.duplicated", "A role já possui esta permissão."));
        }

        if (IsSystem && !permission.IsSystem)
        {
            return Result.Failure(Error.Conflict("role.permission.system-mismatch", "Roles de sistema exigem permissões de sistema."));
        }

        _permissions.Add(permission);
        return Result.Success();
    }

    public Result DetachPermission(Guid permissionId)
    {
        var permission = _permissions.FirstOrDefault(p => p.Id == permissionId);
        if (permission is null)
        {
            return Result.Failure(Error.NotFound("role.permission.not-found", "Permissão não encontrada na role."));
        }

        _permissions.Remove(permission);
        return Result.Success();
    }

    public Result AttachPolicy(Policy policy)
    {
        ArgumentNullException.ThrowIfNull(policy);

        if (_policies.Any(p => p.Id == policy.Id))
        {
            return Result.Failure(Error.Conflict("role.policy.duplicated", "A role já possui esta policy."));
        }

        _policies.Add(policy);
        if (_policies.Count == 1)
        {
            Kind = RoleKind.Policy;
        }

        return Result.Success();
    }

    public Result UpdateDescription(string description)
    {
        if (IsSystem)
        {
            return Result.Failure(Error.Forbidden("role.system.immutable", "Roles de sistema não podem ser alteradas."));
        }

        Description = description?.Trim() ?? string.Empty;
        return Result.Success();
    }

    public Result MarkAsUndeletable() => IsDeletable ? Result.Failure(Error.Conflict("role.already.undeletable", "A role já é indeletável.")) : Result.Success();

    /// <summary>
    /// Seeds a system role with its permission set in one step.
    /// Exposed for the Infrastructure seeders only: the permission matrix is a
    /// reviewed artifact in code, not a runtime input.
    /// </summary>
    public static Result<Role> CreateSystem(
        string name,
        string description,
        IReadOnlyCollection<Permission> permissions)
    {
        var result = Create(name, description, isSystem: true, isDeletable: false);

        if (result.IsFailure)
        {
            return result;
        }

        var role = result.Value;

        foreach (var permission in permissions)
        {
            role.AttachPermission(permission);
        }

        role.ClearDomainEvents();
        return Result.Success(role);
    }
}

/// <summary>
/// Permission is a first-class Entity inside the Role Aggregate. It is also
/// persisted as a standalone catalog so the Admin can list the full catalog and
/// assign permissions without loading every role.
/// </summary>
public sealed class Permission : Entity
{
    private Permission()
    {
    }

    public Permission(Guid id, string name, string resource, string action, string description, bool isSystem)
    {
        Id = id;
        Name = name;
        Resource = resource;
        Action = action;
        Description = description;
        IsSystem = isSystem;
    }

    public string Name { get; private set; } = string.Empty;

    public string Resource { get; private set; } = string.Empty;

    public string Action { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public bool IsSystem { get; private set; }

    public static Result<Permission> Create(string name, string resource, string action, string description, bool isSystem = true)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Permission>(Error.Validation("permission.name.required", "Nome da permissão é obrigatório."));
        }

        if (!string.Equals(name, $"{resource}.{action}", StringComparison.Ordinal))
        {
            return Result.Failure<Permission>(
                Error.Validation("permission.name.inconsistent", "A permissão deve seguir o padrão 'recurso.ação'."));
        }

        return Result.Success(new Permission(Guid.NewGuid(), name, resource, action, description, isSystem));
    }
}

/// <summary>
/// Policy holds the CONDITIONS attached to a policy-driven Role. The condition
/// is stored as a serializable JSON payload and evaluated by the authorization
/// handler - never by the frontend, and never by a controller.
/// </summary>
public sealed class Policy : Entity
{
    private Policy()
    {
    }

    public Policy(Guid id, Guid roleId, string name, string effect, string conditionsJson, bool isSystem)
    {
        Id = id;
        RoleId = roleId;
        Name = name;
        Effect = effect;
        ConditionsJson = conditionsJson;
        IsSystem = isSystem;
    }

    public Guid RoleId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    /// <summary>"Allow" or "Deny". Deny always wins over Allow.</summary>
    public string Effect { get; private set; } = string.Empty;

    public string ConditionsJson { get; private set; } = "{}";

    public bool IsSystem { get; private set; }

    public static Result<Policy> Create(Guid roleId, string name, string effect, string conditionsJson, bool isSystem = false)
    {
        if (roleId == Guid.Empty)
        {
            return Result.Failure<Policy>(Error.Validation("policy.role.required", "Policy deve pertencer a uma role."));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Policy>(Error.Validation("policy.name.required", "Nome da policy é obrigatório."));
        }

        if (!string.Equals(effect, "Allow", StringComparison.OrdinalIgnoreCase)
            && !string.Equals(effect, "Deny", StringComparison.OrdinalIgnoreCase))
        {
            return Result.Failure<Policy>(Error.Validation("policy.effect.invalid", "Effect deve ser 'Allow' ou 'Deny'."));
        }

        if (string.IsNullOrWhiteSpace(conditionsJson))
        {
            return Result.Failure<Policy>(Error.Validation("policy.conditions.required", "Condições da policy são obrigatórias."));
        }

        return Result.Success(new Policy(Guid.NewGuid(), roleId, name.Trim(), effect, conditionsJson, isSystem));
    }
}