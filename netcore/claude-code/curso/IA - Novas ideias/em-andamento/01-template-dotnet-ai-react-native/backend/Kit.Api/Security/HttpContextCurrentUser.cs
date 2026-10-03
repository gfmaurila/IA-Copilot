using System.Security.Claims;
using Kit.Application.Abstractions.Security;
using Kit.Domain.Abstractions;
using Kit.Domain.Modules.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Kit.Api.Security;

/// <summary>
/// Resolves the CURRENT caller from the validated access token.
///
/// It reads the permission list that was embedded in the token, which is safe
/// because <c>Kit.Infrastructure.Security.JwtTokenService</c> only ever writes
/// permissions that IAM already knows about. It is a FAST PATH, not the authority:
/// endpoints that mutate state resolve the permission again through
/// <c>Kit.Application.Abstractions.Security.IAuthorizationService</c>, so revoking
/// access takes effect immediately instead of waiting for the token to expire.
/// </summary>
public sealed class HttpContextCurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextCurrentUser(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    private ClaimsPrincipal? Principal => _httpContextAccessor.HttpContext?.User;

    public bool IsAuthenticated => Principal?.Identity?.IsAuthenticated == true;

    public Guid? UserId
    {
        get
        {
            var raw = Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? Principal?.FindFirst("sub")?.Value;

            return Guid.TryParse(raw, out var id) ? id : null;
        }
    }

    public Guid? OrganizationId
    {
        get
        {
            var raw = Principal?.FindFirst("organization_id")?.Value;
            return Guid.TryParse(raw, out var id) ? id : null;
        }
    }

    public string? Email => Principal?.FindFirst("email")?.Value;

    public IReadOnlyCollection<string> Permissions => Principal?.FindAll("permission")
        .Select(c => c.Value)
        .Distinct(StringComparer.Ordinal)
        .ToList() ?? [];

    public bool HasPermission(string permission)
        => Permissions.Contains(permission, StringComparer.Ordinal);
}

/// <summary>
/// Authorization policies built from the IAM permission catalog.
///
/// Endpoints declare ".RequirePermission(Permissions.ContentPublish)" and the
/// policy name is the permission itself. The catalog stays the single source of
/// truth: a typo fails to resolve the policy and the request is DENIED.
/// </summary>
public static class PermissionAuthorizationPolicies
{
    public static void AddPermissionPolicies(this AuthorizationOptions options)
    {
        options.AddPolicy(AuthorizationPolicyNames.AllowAnonymous, policy => policy.RequireAssertion(_ => true));

        foreach (var permission in Permissions.All.Select(p => p.Name))
        {
            options.AddPolicy(permission, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("permission", permission);
            });
        }
    }
}

public static class AuthorizationPolicyNames
{
    public const string AllowAnonymous = "allow-anonymous";
}

/// <summary>
/// Minimal-API helper so endpoints read as
/// <c>group.RequirePermission(Permissions.ContentPublish)</c>.
/// </summary>
public static class PermissionAuthorizationExtensions
{
    public static RouteHandlerBuilder RequirePermission(
        this RouteHandlerBuilder builder,
        string permission)
    {
        if (!Permissions.Exists(permission))
        {
            throw new InvalidOperationException(
                $"A permissão '{permission}' não existe no catálogo. Um typo aqui resultaria em acesso negado silencioso.");
        }

        return builder.RequireAuthorization(permission);
    }

    public static RouteGroupBuilder RequirePermission(this RouteGroupBuilder builder, string permission)
    {
        if (!Permissions.Exists(permission))
        {
            throw new InvalidOperationException(
                $"A permissão '{permission}' não existe no catálogo. Um typo aqui resultaria em acesso negado silencioso.");
        }

        return builder.RequireAuthorization(permission);
    }
}