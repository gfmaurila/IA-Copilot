using Kit.Domain.Common;

namespace Kit.Domain.Modules.Identity;

/// <summary>
/// User is the IAM Aggregate Root. It owns its credentials, profile, status and
/// its session/refresh-token lifecycle. Authorization data (roles, permissions)
/// is resolved from Role/Group assignments, never hardcoded on the User.
/// </summary>
public sealed class User : AggregateRoot
{
    private readonly List<Session> _sessions = [];
    private readonly List<UserRole> _userRoles = [];
    private readonly List<UserGroup> _userGroups = [];

    private User()
    {
    }

    private User(Guid id, Guid organizationId, string firstName, string lastName, Email email, string passwordHash, string? jobTitle)
    {
        Id = id;
        OrganizationId = organizationId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        JobTitle = jobTitle;
        Status = UserStatus.Active;
    }

    public Guid OrganizationId { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public Email Email { get; private set; } = null!;

    /// <summary>BCrypt hash. The plain password never reaches the Domain.</summary>
    public string PasswordHash { get; private set; } = string.Empty;

    public string? JobTitle { get; private set; }

    public string? AvatarUrl { get; private set; }

    public UserStatus Status { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    public bool MustChangePassword { get; private set; }

    public DateTime? LastLoginAt { get; private set; }

    public string FullName => $"{FirstName} {LastName}".Trim();

    public IReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();

    public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();

    public IReadOnlyCollection<UserGroup> UserGroups => _userGroups.AsReadOnly();

    public static Result<User> Create(
        Guid organizationId,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string? jobTitle = null)
    {
        if (organizationId == Guid.Empty)
        {
            return Result.Failure<User>(Error.Validation("user.organization.required", "Usuário deve pertencer a uma organização."));
        }

        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<User>(Error.Validation("user.firstName.required", "Nome é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<User>(Error.Validation("user.lastName.required", "Sobrenome é obrigatório."));
        }

        var emailResult = Email.Create(email);
        if (emailResult.IsFailure)
        {
            return Result.Failure<User>(emailResult.Error);
        }

        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            return Result.Failure<User>(Error.Validation("user.password.required", "Senha é obrigatória."));
        }

        var user = new User(
            Guid.NewGuid(),
            organizationId,
            firstName.Trim(),
            lastName.Trim(),
            emailResult.Value,
            passwordHash,
            jobTitle?.Trim());

        user.IsEmailConfirmed = true;
        user.RaiseDomainEvent(new UserRegisteredEvent(user.Id, user.Email.Value, user.OrganizationId));
        return Result.Success(user);
    }

    public Result ChangeProfile(string? firstName, string? lastName, string? jobTitle)
    {
        if (!string.IsNullOrWhiteSpace(firstName))
        {
            FirstName = firstName.Trim();
        }

        if (!string.IsNullOrWhiteSpace(lastName))
        {
            LastName = lastName.Trim();
        }

        JobTitle = jobTitle?.Trim();
        return Result.Success();
    }

    public Result ChangeEmail(string newEmail)
    {
        var emailResult = Email.Create(newEmail);
        if (emailResult.IsFailure)
        {
            return Result.Failure(emailResult.Error);
        }

        if (string.Equals(Email.Value, emailResult.Value.Value, StringComparison.Ordinal))
        {
            return Result.Failure(Error.Conflict("user.email.unchanged", "O e-mail já é o mesmo."));
        }

        Email = emailResult.Value;
        IsEmailConfirmed = false;
        RaiseDomainEvent(new UserEmailChangedEvent(Id, Email.Value));
        return Result.Success();
    }

    public Result ChangePassword(string newPasswordHash)
    {
        if (Status == UserStatus.Blocked)
        {
            return Result.Failure(Error.Forbidden("user.blocked.cannot-change-password", "Usuário bloqueado não pode alterar a senha."));
        }

        if (string.IsNullOrWhiteSpace(newPasswordHash))
        {
            return Result.Failure(Error.Validation("user.password.required", "Senha é obrigatória."));
        }

        PasswordHash = newPasswordHash;
        MustChangePassword = false;

        // Changing a password invalidates every other session.
        foreach (var session in _sessions.Where(s => s.Status == SessionStatus.Active))
        {
            session.Revoke("password_changed");
        }

        RaiseDomainEvent(new UserPasswordChangedEvent(Id));
        return Result.Success();
    }

    public Result Block(string reason)
    {
        if (Status == UserStatus.Blocked)
        {
            return Result.Failure(Error.Conflict("user.already.blocked", "Usuário já está bloqueado."));
        }

        Status = UserStatus.Blocked;
        foreach (var session in _sessions.Where(s => s.Status == SessionStatus.Active))
        {
            session.Revoke("user_blocked");
        }

        RaiseDomainEvent(new UserBlockedEvent(Id, reason));
        return Result.Success();
    }

    public Result Unblock()
    {
        if (Status != UserStatus.Blocked)
        {
            return Result.Failure(Error.Conflict("user.not.blocked", "Usuário não está bloqueado."));
        }

        Status = UserStatus.Active;
        RaiseDomainEvent(new UserUnblockedEvent(Id));
        return Result.Success();
    }

    public Result Deactivate()
    {
        if (Status == UserStatus.Inactive)
        {
            return Result.Failure(Error.Conflict("user.already.inactive", "Usuário já está inativo."));
        }

        Status = UserStatus.Inactive;
        return Result.Success();
    }

    public Result RegisterSession(string tokenHash, string? ipAddress, string? userAgent, DateTime expiresAtUtc)
    {
        if (Status == UserStatus.Blocked)
        {
            return Result.Failure(Error.Forbidden("user.blocked", "Usuário bloqueado não pode iniciar sessão."));
        }

        if (Status == UserStatus.Inactive)
        {
            return Result.Failure(Error.Forbidden("user.inactive", "Usuário inativo não pode iniciar sessão."));
        }

        var session = Session.Start(Id, tokenHash, ipAddress, userAgent, expiresAtUtc);
        _sessions.Add(session);
        LastLoginAt = session.StartedAtUtc;
        RaiseDomainEvent(new UserLoggedInEvent(Id, session.Id));
        return Result.Success(session);
    }

    public Result EndSession(Guid sessionId, string reason = "logout")
    {
        var session = _sessions.FirstOrDefault(s => s.Id == sessionId);
        if (session is null)
        {
            return Result.Failure(Error.NotFound("session.not-found", "Sessão não encontrada."));
        }

        var revoked = session.Revoke(reason);
        if (revoked.IsFailure)
        {
            return revoked;
        }

        RaiseDomainEvent(new UserLoggedOutEvent(Id, sessionId, reason));
        return Result.Success();
    }

    public Result AssignRole(Role role)
    {
        ArgumentNullException.ThrowIfNull(role);

        if (_userRoles.Any(r => r.RoleId == role.Id))
        {
            return Result.Failure(Error.Conflict("user.role.duplicated", "Usuário já possui esta role."));
        }

        var assignment = UserRole.Create(Id, role.Id);
        _userRoles.Add(assignment);
        RaiseDomainEvent(new UserRoleAssignedEvent(Id, role.Id));
        return Result.Success();
    }

    public Result RemoveRole(Guid roleId)
    {
        var assignment = _userRoles.FirstOrDefault(r => r.RoleId == roleId);
        if (assignment is null)
        {
            return Result.Failure(Error.NotFound("user.role.not-found", "Usuário não possui esta role."));
        }

        _userRoles.Remove(assignment);
        RaiseDomainEvent(new UserRoleRemovedEvent(Id, roleId));
        return Result.Success();
    }

    public Result JoinGroup(Guid groupId)
    {
        if (_userGroups.Any(g => g.GroupId == groupId))
        {
            return Result.Failure(Error.Conflict("user.group.duplicated", "Usuário já pertence a este grupo."));
        }

        _userGroups.Add(UserGroup.Create(Id, groupId));
        return Result.Success();
    }

    public Result LeaveGroup(Guid groupId)
    {
        var membership = _userGroups.FirstOrDefault(g => g.GroupId == groupId);
        if (membership is null)
        {
            return Result.Failure(Error.NotFound("user.group.not-found", "Usuário não pertence a este grupo."));
        }

        _userGroups.Remove(membership);
        return Result.Success();
    }

    public void AddSeededRole(Guid roleId)
    {
        if (!_userRoles.Any(r => r.RoleId == roleId))
        {
            _userRoles.Add(UserRole.Create(Id, roleId));
        }
    }

    public void AddSeededGroup(Guid groupId)
    {
        if (!_userGroups.Any(g => g.GroupId == groupId))
        {
            _userGroups.Add(UserGroup.Create(Id, groupId));
        }
    }

    public void AddSeededSession(Session session) => _sessions.Add(session);

    public void ReplaceHash(string passwordHash) => PasswordHash = passwordHash;

    /// <summary>
    /// Seeds a deterministic demo/stress user. Only the Infrastructure seeders call
    /// this, so the convenience of forcing a Status without a domain transition is
    /// not part of the production creation path.
    /// </summary>
    public static Result<User> CreateSeeded(
        Guid organizationId,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string? jobTitle = null,
        bool isEmailConfirmed = true,
        UserStatus status = UserStatus.Active)
    {
        var result = Create(organizationId, firstName, lastName, email, passwordHash, jobTitle);

        if (result.IsFailure)
        {
            return result;
        }

        var user = result.Value;
        user.Status = status;
        user.IsEmailConfirmed = isEmailConfirmed;
        user.ClearDomainEvents();
        return Result.Success(user);
    }
}

/// <summary>
/// Join Entity between User and Role inside the User Aggregate.
/// </summary>
public sealed class UserRole : Entity
{
    private UserRole()
    {
    }

    public Guid UserId { get; private set; }

    public Guid RoleId { get; private set; }

    internal static UserRole Create(Guid userId, Guid roleId) => new() { Id = Guid.NewGuid(), UserId = userId, RoleId = roleId };
}

/// <summary>
/// Join Entity between User and Group inside the User Aggregate.
/// </summary>
public sealed class UserGroup : Entity
{
    private UserGroup()
    {
    }

    public Guid UserId { get; private set; }

    public Guid GroupId { get; private set; }

    internal static UserGroup Create(Guid userId, Guid groupId) => new() { Id = Guid.NewGuid(), UserId = userId, GroupId = groupId };
}

public sealed record UserRegisteredEvent(Guid UserId, string Email, Guid OrganizationId) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.registered";
}

public sealed record UserEmailChangedEvent(Guid UserId, string Email) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.email-changed";
}

public sealed record UserPasswordChangedEvent(Guid UserId) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.password-changed";
}

public sealed record UserBlockedEvent(Guid UserId, string Reason) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.blocked";
}

public sealed record UserUnblockedEvent(Guid UserId) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.unblocked";
}

public sealed record UserLoggedInEvent(Guid UserId, Guid SessionId) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.logged-in";
}

public sealed record UserLoggedOutEvent(Guid UserId, Guid SessionId, string Reason) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.logged-out";
}

public sealed record UserRoleAssignedEvent(Guid UserId, Guid RoleId) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.role-assigned";
}

public sealed record UserRoleRemovedEvent(Guid UserId, Guid RoleId) : DomainEventBase(UserId)
{
    public override string EventName => "identity.user.role-removed";
}