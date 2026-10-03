using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

/// <summary>
/// Group is a named collection used to grant roles in bulk (GroupRoles).
/// It is deliberately separate from Team: a Team is organizational, a Group
/// exists to attach roles to many users at once.
/// Membership is owned by the User Aggregate (<c>User.UserGroups</c>) - there is
/// exactly one source of truth for "who is in this group".
/// </summary>
public sealed class Group : AggregateRoot
{
    private readonly List<GroupRole> _groupRoles = [];

    private Group()
    {
    }

    private Group(Guid id, string name, string description, string? parentGroupId, GroupStatus status)
    {
        Id = id;
        Name = name;
        Description = description;
        ParentGroupId = parentGroupId;
        Status = status;
    }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string? ParentGroupId { get; private set; }

    public GroupStatus Status { get; private set; }

    public IReadOnlyCollection<GroupRole> GroupRoles => _groupRoles.AsReadOnly();

    public static Result<Group> Create(string name, string description, string? parentGroupId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Group>(Error.Validation("group.name.required", "Nome do grupo é obrigatório."));
        }

        return Result.Success(new Group(
            Guid.NewGuid(),
            name.Trim(),
            description?.Trim() ?? string.Empty,
            parentGroupId,
            GroupStatus.Active));
    }

    /// <summary>
    /// Grants a Role to every member of the Group.
    /// </summary>
    public Result AssignRole(Guid roleId)
    {
        if (roleId == Guid.Empty)
        {
            return Result.Failure(Error.Validation("group.role.required", "Role é obrigatória."));
        }

        if (_groupRoles.Any(r => r.RoleId == roleId))
        {
            return Result.Failure(Error.Conflict("group.role.duplicated", "O grupo já possui esta role."));
        }

        _groupRoles.Add(GroupRole.Create(Id, roleId));
        RaiseDomainEvent(new GroupRoleAssignedEvent(Id, roleId));
        return Result.Success();
    }

    public Result RemoveRole(Guid roleId)
    {
        var assignment = _groupRoles.FirstOrDefault(r => r.RoleId == roleId);
        if (assignment is null)
        {
            return Result.Failure(Error.NotFound("group.role.not-found", "O grupo não possui esta role."));
        }

        _groupRoles.Remove(assignment);
        return Result.Success();
    }

    public Result ChangeStatus(GroupStatus status)
    {
        if (Status == status)
        {
            return Result.Failure(Error.Conflict("group.status.unchanged", "O grupo já está neste status."));
        }

        Status = status;
        RaiseDomainEvent(new GroupStatusChangedEvent(Id, status));
        return Result.Success();
    }

    public void AddSeededRole(Guid roleId)
    {
        if (!_groupRoles.Any(r => r.RoleId == roleId))
        {
            _groupRoles.Add(GroupRole.Create(Id, roleId));
        }
    }
}

public sealed record GroupStatusChangedEvent(Guid GroupId, GroupStatus Status) : DomainEventBase(GroupId)
{
    public override string EventName => "identity.group.status-changed";
}

public sealed record GroupRoleAssignedEvent(Guid GroupId, Guid RoleId) : DomainEventBase(GroupId)
{
    public override string EventName => "identity.group.role-assigned";
}