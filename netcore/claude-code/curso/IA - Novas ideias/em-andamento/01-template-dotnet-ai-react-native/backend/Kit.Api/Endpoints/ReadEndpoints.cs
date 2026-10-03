using Kit.Api.Contracts;
using Kit.Api.Security;
using Kit.Application.Abstractions.Repositories;
using Kit.Application.Common;
using Kit.CrossCutting.FeatureFlags;
using Kit.Domain.Common;
using Kit.Domain.Modules.Content;
using Kit.Domain.Modules.Identity;

namespace Kit.Api.Endpoints;

/// <summary>
/// Read endpoints over the IAM and Content read models.
///
/// Every handler here is a QUERY: they never mutate state. A query bypasses the
/// Unit of Work behavior on purpose (only commands commit), which is why they use
/// the repository ports directly instead of a Command.
/// </summary>
public static class ReadEndpoints
{
    public static void MapReadEndpoints(this WebApplication app, IFeatureFlagReader featureFlags)
    {
        MapIdentity(app);
        MapContent(app, featureFlags.IsEnabled(nameof(FeatureFlagsOptions.Content)));
    }

    private static void MapIdentity(WebApplication app)
    {
        var identity = app.MapGroup("/api/identity").WithTags("Identity");

        identity.MapGet("/permissions", async (HttpContext context, CancellationToken cancellationToken) =>
        {
            var permissions = Permissions.All
                .Select(p => new PermissionDto(p.Name, p.Resource, p.Action, p.Description))
                .ToList();

            return Results.Ok(permissions);
        })
        .RequirePermission(Permissions.PermissionsRead)
        .WithSummary("Catalogo canonico de permissoes da plataforma.");

        identity.MapGet("/roles", async (
            IRoleRepository roleRepository,
            HttpContext context,
            CancellationToken cancellationToken) =>
        {
            var roles = await roleRepository.ListAsync(cancellationToken: cancellationToken);

            var response = roles
                .Select(r => new RoleDto(r.Id, r.Name, r.Description, r.Kind.ToString(), r.IsSystem,
                    r.Permissions.Count))
                .OrderBy(r => r.Name)
                .ToList();

            return Results.Ok(response);
        })
        .RequirePermission(Permissions.RolesRead)
        .WithSummary("Lista as roles e a quantidade de permissoes de cada uma.");

        identity.MapGet("/users", async (
            IUserRepository userRepository,
            HttpContext context,
            CancellationToken cancellationToken) =>
        {
            var query = context.Request.Query["q"].ToString();
            var page = ParsePage(context.Request.Query["page"]);
            var pageSize = ParsePageSize(context.Request.Query["pageSize"]);

            var users = await userRepository.ListAsync(cancellationToken: cancellationToken);
            var total = users.Count;

            var filtered = string.IsNullOrWhiteSpace(query)
                ? users
                : [.. users.Where(u => u.Email.Value.Contains(query, StringComparison.OrdinalIgnoreCase)
                                       || u.FullName.Contains(query, StringComparison.OrdinalIgnoreCase))];

            var items = filtered
                .OrderBy(u => u.FullName, StringComparer.OrdinalIgnoreCase)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UserSummaryDto(u.Id, u.FullName, u.Email.Value, u.Status.ToString(), u.LastLoginAt))
                .ToList();

            return Results.Ok(new ApiPagedResponse<UserSummaryDto>(items, page, pageSize, filtered.Count));
        })
        .RequirePermission(Permissions.UsersRead)
        .WithSummary("Lista usuarios com paginacao e busca opcional.");
    }

    private static void MapContent(WebApplication app, bool contentEnabled)
    {
        // A disabled module is ABSENT, not hidden: the route does not exist, so
        // there is no request that can reach an unauthorized handler.
        if (!contentEnabled)
        {
            app.Logger.LogWarning(
                "Modulo Content desativado em FeatureFlags. As rotas /api/content nao foram registradas.");
            return;
        }

        var content = app.MapGroup("/api/content").WithTags("Content");

        content.MapGet("/types", async (
            IContentTypeRepository repository,
            HttpContext context,
            CancellationToken cancellationToken) =>
        {
            var types = await repository.ListAsync(cancellationToken: cancellationToken);

            var response = types
                .Select(t => new ContentTypeDto(t.Id, t.Name, t.Slug, t.Description, t.IsSystem,
                    t.Fields.OrderBy(f => f.Position).Select(f => new FieldDto(f.Name, f.Type.ToString(), f.IsRequired, f.Position)).ToList()))
                .OrderBy(t => t.Slug, StringComparer.Ordinal)
                .ToList();

            return Results.Ok(response);
        })
        .RequirePermission(Permissions.ContentRead)
        .WithSummary("Lista os tipos de conteudo e o schema de cada um.");

        content.MapGet("/items/{contentTypeSlug}", async (
            string contentTypeSlug,
            IContentTypeRepository typeRepository,
            IContentItemRepository itemRepository,
            HttpContext context,
            CancellationToken cancellationToken) =>
        {
            var typeResult = await typeRepository.FindBySlugAsync(contentTypeSlug, cancellationToken);

            if (typeResult is null)
            {
                return Error.NotFound("content-type.not-found", "Tipo de conteudo nao encontrado.")
                    .ToHttpResult(context);
            }

            var page = ParsePage(context.Request.Query["page"]);
            var pageSize = ParsePageSize(context.Request.Query["pageSize"]);
            var search = context.Request.Query["q"].ToString();

            var items = await itemRepository.ListPublishedAsync(
                typeResult.Id,
                string.IsNullOrWhiteSpace(search) ? null : search,
                page,
                pageSize,
                cancellationToken);

            var response = items
                .Select(i => new ContentItemDto(i.Id, i.Slug, i.Title, i.Summary, i.Status.ToString(),
                    i.PublishedAtUtc, i.PayloadJson))
                .ToList();

            return Results.Ok(new ApiPagedResponse<ContentItemDto>(response, page, pageSize, response.Count));
        })
        .RequirePermission(Permissions.ContentRead)
        .WithSummary("Lista os itens publicados de um tipo de conteudo.");
    }

    private static int ParsePage(string? raw) => ParseBounded(raw, defaultValue: 1, min: 1, max: 10_000);

    private static int ParsePageSize(string? raw) => ParseBounded(raw, defaultValue: 20, min: 1, max: 100);

    /// <summary>
    /// Pagination values come from user input, so they are clamped instead of
    /// trusted: a negative page or an unbounded pageSize is a trivial DoS.
    /// </summary>
    private static int ParseBounded(string? raw, int defaultValue, int min, int max)
        => int.TryParse(raw, out var parsed) ? Math.Clamp(parsed, min, max) : defaultValue;
}

public sealed record PermissionDto(string Name, string Resource, string Action, string Description);

public sealed record RoleDto(Guid Id, string Name, string Description, string Kind, bool IsSystem, int PermissionCount);

public sealed record UserSummaryDto(Guid Id, string FullName, string Email, string Status, DateTime? LastLoginAt);

public sealed record FieldDto(string Name, string Type, bool IsRequired, int Position);

public sealed record ContentTypeDto(
    Guid Id,
    string Name,
    string Slug,
    string Description,
    bool IsSystem,
    IReadOnlyList<FieldDto> Fields);

public sealed record ContentItemDto(
    Guid Id,
    string Slug,
    string Title,
    string? Summary,
    string Status,
    DateTime? PublishedAtUtc,
    string PayloadJson);