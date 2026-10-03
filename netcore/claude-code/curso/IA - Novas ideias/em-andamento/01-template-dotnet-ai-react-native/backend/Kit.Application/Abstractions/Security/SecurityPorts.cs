using Kit.Domain.Common;
using Kit.Domain.Modules.Identity;

namespace Kit.Application.Abstractions.Security;

/// <summary>
/// Password hashing port. BCrypt lives in Infrastructure; the Application layer
/// only knows that passwords are hashed and verified, never how.
/// </summary>
public interface IPasswordHasher
{
    string Hash(string plainPassword);

    bool Verify(string plainPassword, string passwordHash);
}

/// <summary>
/// Token issuing port. The signing key and algorithm are Infrastructure concerns.
/// </summary>
public interface ITokenService
{
    TokenPair IssueAccessToken(User user, IReadOnlyCollection<string> roles, IReadOnlyCollection<string> permissions);

    TokenPrincipal? ValidateAccessToken(string token);

    string CreateRefreshToken();

    string HashToken(string token);
}

public sealed record TokenPair(
    string AccessToken,
    DateTime AccessTokenExpiresAtUtc,
    string RefreshToken,
    DateTime RefreshTokenExpiresAtUtc);

public sealed record TokenPrincipal(
    Guid UserId,
    Guid? OrganizationId,
    string Email,
    IReadOnlyList<string> Roles,
    IReadOnlyList<string> Permissions);

/// <summary>
/// Read-side port that resolves the effective permission set of a user.
/// Effective set = permissions from direct roles + permissions inherited from the
/// roles of every group the user belongs to.
/// This is a READ MODEL: it must be implemented with a projection/join, not by
/// loading the whole aggregate graph into memory.
/// </summary>
public interface IUserPermissionReader
{
    Task<IReadOnlyCollection<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<string>> GetPermissionsAsync(Guid userId, CancellationToken cancellationToken = default);
}

/// <summary>
/// Cache PORT. Business code depends on this interface, never on Redis or
/// IMemoryCache, so switching the backing store never touches a handler.
/// </summary>
public interface ICacheService
{
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    Task SetAsync<T>(string key, T value, TimeSpan? ttl = null, CancellationToken cancellationToken = default);

    Task RemoveAsync(string key, CancellationToken cancellationToken = default);

    Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        TimeSpan? ttl = null,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Central authorization decision point used by AI Tools as well as by the API.
/// A Tool may NEVER decide authorization on its own - it delegates here.
/// </summary>
public interface IAuthorizationService
{
    Task<bool> HasPermissionAsync(Guid userId, string permission, CancellationToken cancellationToken = default);

    Task<Result> EnsurePermissionAsync(Guid userId, string permission, CancellationToken cancellationToken = default);
}