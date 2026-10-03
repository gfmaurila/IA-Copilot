using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

public enum UserStatus
{
    Active = 1,
    Blocked = 2,
    Inactive = 3
}

public enum OrganizationStatus
{
    Active = 1,
    Suspended = 2
}

public enum TeamStatus
{
    Active = 1,
    Inactive = 2
}

public enum GroupStatus
{
    Active = 1,
    Inactive = 2
}

public enum SessionStatus
{
    Active = 1,
    Expired = 2,
    Revoked = 3
}

public enum RoleKind
{
    /// <summary>Grants a fixed set of permissions.</summary>
    Permission = 1,

    /// <summary>
    /// Grants a permission only when an ABAC-like condition holds. Stored as
    /// JSON so policy logic never leaks into controllers or repositories.
    /// </summary>
    Policy = 2
}