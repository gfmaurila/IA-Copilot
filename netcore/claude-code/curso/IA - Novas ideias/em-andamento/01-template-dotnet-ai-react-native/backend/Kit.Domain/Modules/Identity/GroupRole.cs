using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

/// <summary>
/// Join Entity between Group and Role, owned by the Group Aggregate.
/// This is what lets a whole group inherit permissions without assigning roles
/// to every member individually.
/// </summary>
public sealed class GroupRole : Entity
{
    private GroupRole()
    {
    }

    public Guid GroupId { get; private set; }

    public Guid RoleId { get; private set; }

    internal static GroupRole Create(Guid groupId, Guid roleId) => new() { Id = Guid.NewGuid(), GroupId = groupId, RoleId = roleId };
}