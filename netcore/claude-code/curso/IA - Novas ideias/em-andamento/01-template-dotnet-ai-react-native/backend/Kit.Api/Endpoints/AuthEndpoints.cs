using Kit.Api.Contracts;
using Kit.Api.Security;
using Kit.Application.Modules.Identity.Auth;
using Kit.Domain.Common;
using MediatR;

namespace Kit.Api.Endpoints;

public sealed record LoginRequest(string Email, string Password);

/// <summary>
/// Authentication endpoints.
///
/// THIN BY CONTRACT: this file maps HTTP to a Command and back. It contains no
/// business rule, no database access and no token logic - all of that belongs to
/// the Application and Infrastructure layers.
/// </summary>
public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/auth")
            .WithTags("Auth")
            .RequireAuthorization(AuthorizationPolicyNames.AllowAnonymous);

        group.MapPost("/login", LoginAsync)
            .WithName("Login")
            .WithSummary("Autentica um usuario e devolve o par de tokens.")
            .Produces<LoginResponse>()
            .Produces<ApiErrorResponse>(StatusCodes.Status401Unauthorized)
            .RequireRateLimiting("login")
            .AllowAnonymous();
    }

    private static async Task<IResult> LoginAsync(
        LoginRequest request,
        ISender sender,
        HttpContext context,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            new LoginCommand(request.Email, request.Password),
            cancellationToken);

        if (result.IsFailure)
        {
            return result.Error.ToHttpResult(context);
        }

        return Results.Ok(result.Value);
    }
}

/// <summary>
/// Liveness / readiness probes used by Docker Compose and by the deployment
/// platform. They are anonymous on purpose: an orchestrator must be able to probe
/// the container before authentication exists.
/// </summary>
public static class HealthEndpoints
{
    public static void MapHealthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/health").WithTags("Health").AllowAnonymous();

        // Liveness: is the process running? Must not touch the database, otherwise
        // a transient DB outage would cause the orchestrator to kill a healthy pod.
        group.MapGet("/live", () => Results.Ok(new { status = "alive", utc = DateTime.UtcNow }))
            .WithName("Liveness");

        // Readiness: can the process serve traffic? This one DOES check MySQL.
        group.MapGet("/ready", async (
            Kit.Infrastructure.Persistence.Context.KitDbContext dbContext,
            CancellationToken cancellationToken) =>
        {
            try
            {
                var canConnect = await dbContext.Database.CanConnectAsync(cancellationToken);
                return canConnect
                    ? Results.Ok(new { status = "ready", database = "up" })
                    : Results.Json(new { status = "not-ready", database = "down" }, statusCode: StatusCodes.Status503ServiceUnavailable);
            }
            catch (Exception exception)
            {
                return Results.Json(
                    new { status = "not-ready", database = "down", error = exception.Message },
                    statusCode: StatusCodes.Status503ServiceUnavailable);
            }
        })
        .WithName("Readiness");
    }
}