using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Kit.Application.Abstractions.Security;
using Kit.Domain.Abstractions;
using Kit.Domain.Modules.Identity;
using Kit.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Kit.Infrastructure.Security;

public sealed class BcryptPasswordHasher : IPasswordHasher
{
    private const int WorkFactor = 12;

    public string Hash(string plainPassword)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(plainPassword);
        return BCrypt.Net.BCrypt.HashPassword(plainPassword, WorkFactor);
    }

    public bool Verify(string plainPassword, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(plainPassword) || string.IsNullOrWhiteSpace(passwordHash))
        {
            return false;
        }

        try
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, passwordHash);
        }
        catch (BCrypt.Net.SaltParseException)
        {
            return false;
        }
    }
}

/// <summary>
/// Issues and validates access tokens.
///
/// SECURITY RULES:
///  - the signing key is required; there is no default and no generated-at-runtime
///    fallback, so a misconfigured deployment fails fast instead of signing tokens
///    with a predictable key;
///  - roles AND permissions are embedded so the API can authorize without a
///    database round trip, but the API remains the final authority - a token can
///    never grant a permission that IAM does not know about, because
///    <see cref="Permissions"/> is the catalog the Admin screens also render;
///  - refresh tokens and API keys are stored only as SHA-256 hashes.
/// </summary>
public sealed class JwtTokenService : ITokenService
{
    private readonly JwtOptions _options;
    private readonly IClock _clock;
    private readonly SymmetricSecurityKey _signingKey;

    public JwtTokenService(IOptions<JwtOptions> options, IClock clock)
    {
        _options = options.Value;
        _clock = clock;

        if (string.IsNullOrWhiteSpace(_options.SigningKey) || _options.SigningKey.Length < 32)
        {
            throw new InvalidOperationException(
                "Jwt:SigningKey não configurada ou menor que 32 caracteres. Configure via variável de ambiente, " +
                "docker-compose ou user-secrets. Nunca commite esta chave.");
        }

        _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey));
    }

    public TokenPair IssueAccessToken(User user, IReadOnlyCollection<string> roles, IReadOnlyCollection<string> permissions)
    {
        var now = _clock.UtcNow;
        var expiresAt = now.AddMinutes(_options.AccessTokenMinutes);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email.Value),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new("organization_id", user.OrganizationId.ToString()),
            new("full_name", user.FullName)
        };

        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
        claims.AddRange(permissions.Select(p => new Claim("permission", p)));

        var credentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: now,
            expires: expiresAt,
            signingCredentials: credentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshExpiresAt = now.AddDays(_options.RefreshTokenDays);

        return new TokenPair(accessToken, expiresAt, CreateRefreshToken(), refreshExpiresAt);
    }

    public TokenPrincipal? ValidateAccessToken(string token)
    {
        try
        {
            var principal = new JwtSecurityTokenHandler().ValidateToken(
                token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = _options.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _options.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30),
                    NameClaimType = ClaimTypes.NameIdentifier
                },
                out _);

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            if (!Guid.TryParse(userIdClaim, out var userId))
            {
                return null;
            }

            Guid? organizationId = Guid.TryParse(principal.FindFirst("organization_id")?.Value, out var orgId)
                ? orgId
                : null;

            return new TokenPrincipal(
                userId,
                organizationId,
                principal.FindFirst(JwtRegisteredClaimNames.Email)?.Value ?? string.Empty,
                principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList(),
                principal.FindAll("permission").Select(c => c.Value).Distinct(StringComparer.Ordinal).ToList());
        }
        catch (SecurityTokenException)
        {
            return null;
        }
        catch (ArgumentException)
        {
            return null;
        }
    }

    public string CreateRefreshToken()
    {
        var bytes = RandomNumberGenerator.GetBytes(48);
        return Base64UrlEncode(bytes);
    }

    public string HashToken(string token)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(bytes);
    }

    private static string Base64UrlEncode(byte[] bytes) =>
        Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
}

/// <summary>
/// Resolves the EFFECTIVE permission set of a user as a read model:
/// direct UserRoles + the roles granted to every Group the user belongs to.
/// Implemented as a set-based join so it never loads the aggregate graph.
/// </summary>
public sealed class UserPermissionReader : IUserPermissionReader
{
    private readonly Persistence.Context.KitDbContext _context;

    public UserPermissionReader(Persistence.Context.KitDbContext context) => _context = context;

    public async Task<IReadOnlyCollection<string>> GetRolesAsync(Guid userId, CancellationToken cancellationToken = default)
        => await RoleNamesQuery(userId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyCollection<string>> GetPermissionsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var permissions = await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .SelectMany(ur => _context.Roles
                .Where(r => r.Id == ur.RoleId)
                .SelectMany(r => r.Permissions.Select(p => p.Name)))
            .Concat(_context.UserGroups
                .Where(ug => ug.UserId == userId)
                .SelectMany(ug => _context.GroupRoles
                    .Where(gr => gr.GroupId == ug.GroupId)
                    .SelectMany(gr => _context.Roles
                        .Where(r => r.Id == gr.RoleId)
                        .SelectMany(r => r.Permissions.Select(p => p.Name)))))
            .Distinct()
            .ToListAsync(cancellationToken);

        return permissions;
    }

    /// <summary>Role names granted directly to the user plus the roles of every group they belong to.</summary>
    private IQueryable<string> RoleNamesQuery(Guid userId) => _context.UserRoles
        .Where(ur => ur.UserId == userId)
        .Join(_context.Roles, ur => ur.RoleId, r => r.Id, (_, r) => r.Name)
        .Concat(
            _context.UserGroups
                .Where(ug => ug.UserId == userId)
                .Join(_context.GroupRoles, ug => ug.GroupId, gr => gr.GroupId, (_, gr) => gr.RoleId)
                .Join(_context.Roles, roleId => roleId, r => r.Id, (_, r) => r.Name))
        .Distinct();
}

/// <summary>
/// Single decision point for authorization, used by BOTH the API and AI Tools.
/// Deny always wins over Allow.
/// </summary>
public sealed class AuthorizationService : IAuthorizationService
{
    private readonly IUserPermissionReader _permissionReader;

    public AuthorizationService(IUserPermissionReader permissionReader) => _permissionReader = permissionReader;

    public async Task<bool> HasPermissionAsync(Guid userId, string permission, CancellationToken cancellationToken = default)
    {
        if (!Permissions.Exists(permission))
        {
            // Unknown permissions are denied by default. A typo in a policy must
            // never silently grant access.
            return false;
        }

        var permissions = await _permissionReader.GetPermissionsAsync(userId, cancellationToken);
        return permissions.Contains(permission, StringComparer.Ordinal);
    }

    public async Task<Domain.Common.Result> EnsurePermissionAsync(Guid userId, string permission, CancellationToken cancellationToken = default)
    {
        var allowed = await HasPermissionAsync(userId, permission, cancellationToken);

        return allowed
            ? Domain.Common.Result.Success()
            : Domain.Common.Result.Failure(
                Domain.Common.Error.Forbidden("authorization.permission-denied", $"Permissão negada: {permission}"));
    }
}

public sealed class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;

    public DateTimeOffset UtcNowOffset => DateTimeOffset.UtcNow;
}