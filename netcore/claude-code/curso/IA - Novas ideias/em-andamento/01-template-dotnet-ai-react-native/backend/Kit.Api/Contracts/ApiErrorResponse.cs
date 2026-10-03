using System.Text.Json;
using Kit.Domain.Common;

namespace Kit.Api.Contracts;

/// <summary>
/// Transport shape of an error returned by the API.
///
/// The mapping from a Domain <see cref="Error"/> to HTTP lives HERE and nowhere
/// else, so a handler never decides a status code and the same Error always yields
/// the same HTTP response across every endpoint.
/// </summary>
public sealed record ApiErrorResponse(
    string Type,
    string Title,
    int Status,
    string Code,
    string Detail,
    string TraceId,
    IReadOnlyDictionary<string, string[]>? Errors = null);

public sealed record ApiPagedResponse<T>(IReadOnlyList<T> Items, int Page, int PageSize, int Total);

public static class ApiErrorMapper
{
    public static IResult ToHttpResult(this Error error, HttpContext context, IReadOnlyDictionary<string, string[]>? validationErrors = null)
    {
        var status = MapStatus(error.Type);

        var payload = new ApiErrorResponse(
            Type: $"https://httpstatuses.io/{status}",
            Title: ReasonPhrases(status),
            Status: status,
            Code: error.Code,
            Detail: error.Message,
            TraceId: context.TraceIdentifier,
            Errors: validationErrors);

        return Results.Json(payload, statusCode: status, contentType: "application/problem+json");
    }

    /// <summary>
    /// The single place where a Domain ErrorType becomes an HTTP status code.
    /// A plain Failure maps to 400 because it is always a rejected request.
    /// </summary>
    public static int MapStatus(ErrorType errorType) => errorType switch
    {
        ErrorType.Validation => StatusCodes.Status400BadRequest,
        ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
        ErrorType.Forbidden => StatusCodes.Status403Forbidden,
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        ErrorType.Conflict => StatusCodes.Status409Conflict,
        ErrorType.None => StatusCodes.Status500InternalServerError,
        _ => StatusCodes.Status400BadRequest
    };

    public static string ReasonPhrases(int status) => status switch
    {
        StatusCodes.Status400BadRequest => "Bad Request",
        StatusCodes.Status401Unauthorized => "Unauthorized",
        StatusCodes.Status403Forbidden => "Forbidden",
        StatusCodes.Status404NotFound => "Not Found",
        StatusCodes.Status409Conflict => "Conflict",
        StatusCodes.Status500InternalServerError => "Internal Server Error",
        _ => "Error"
    };
}

public static class ResultExtensions
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    /// <summary>
    /// Unwraps a Result into a minimal-API result.
    /// An empty success maps to 204 No Content; a typed success maps to 200 with JSON.
    /// </summary>
    public static IResult ToApiResult<T>(this Result<T> result, HttpContext context, int successStatusCode = StatusCodes.Status200OK)
    {
        if (result.IsFailure)
        {
            return result.Error.ToHttpResult(context);
        }

        if (result.Value is null)
        {
            return Results.NoContent();
        }

        return Results.Json(result.Value, options: SerializerOptions, contentType: "application/json", statusCode: successStatusCode);
    }

    public static IResult ToApiResult(this Result result, HttpContext context, int successStatusCode = StatusCodes.Status204NoContent)
        => result.IsFailure
            ? result.Error.ToHttpResult(context)
            : Results.StatusCode(successStatusCode);

    public static IResult ToApiResult(this Result result, HttpContext context, object successValue, int successStatusCode = StatusCodes.Status200OK)
        => result.IsFailure
            ? result.Error.ToHttpResult(context)
            : Results.Json(successValue, options: SerializerOptions, contentType: "application/json", statusCode: successStatusCode);
}