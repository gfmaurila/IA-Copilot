using System.Diagnostics;
using System.Text.Json;
using Kit.Api.Contracts;
using Kit.CrossCutting.Time;

namespace Kit.Api.Middleware;

/// <summary>
/// Outermost middleware. Converts an unhandled exception into RFC 7807 Problem
/// Details with a stable shape.
///
/// SECURITY: the message is only echoed to the client outside Production. In
/// Production the client gets a generic message and the real one goes to the log,
/// correlated by TraceId - otherwise stack traces and connection strings leak.
/// </summary>
public sealed class ExceptionHandlingMiddleware
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            // The client hung up. Not an error, and not worth a stack trace.
            _logger.LogDebug("Request {Path} aborted by the client", context.Request.Path);
        }
        catch (Exception exception)
        {
            await HandleAsync(context, exception);
        }
    }

    private async Task HandleAsync(HttpContext context, Exception exception)
    {
        if (context.Response.HasStarted)
        {
            _logger.LogWarning(exception, "Response already started; exception cannot be serialized");
            throw exception;
        }

        var isProduction = _environment.IsProduction();
        var errorCode = isProduction ? "internal.error" : exception.GetType().Name;
        var detail = isProduction
            ? "Ocorreu um erro inesperado. Tente novamente ou contate o suporte."
            : exception.Message;

        if (isProduction)
        {
            _logger.LogError(exception, "Unhandled exception on {Method} {Path}", context.Request.Method, context.Request.Path);
        }
        else
        {
            _logger.LogError(exception, "Unhandled exception on {Method} {Path} (details exposed: Development)", context.Request.Method, context.Request.Path);
        }

        context.Response.Clear();
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";

        var payload = new ApiErrorResponse(
            Type: "https://httpstatuses.io/500",
            Title: "Internal Server Error",
            Status: StatusCodes.Status500InternalServerError,
            Code: errorCode,
            Detail: detail,
            TraceId: context.TraceIdentifier);

        await context.Response.WriteAsync(JsonSerializer.Serialize(payload, SerializerOptions));
    }
}

/// <summary>
/// Resolves a Correlation Id for the request and echoes it back as a response
/// header, so a user-reported problem can be traced through the logs.
/// The id is also stored in the accessor for Domain Events and Audit entries.
/// </summary>
public sealed class CorrelationIdMiddleware
{
    public const string HeaderName = "X-Correlation-Id";

    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, ICorrelationIdAccessor accessor)
    {
        var correlationId = context.Request.Headers[HeaderName].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(correlationId) || correlationId.Length > 128)
        {
            correlationId = Guid.NewGuid().ToString("N");
        }

        accessor.Set(correlationId);
        context.Items[HeaderName] = correlationId;
        context.Response.Headers[HeaderName] = correlationId;

        using var activity = Activity.Current?.SetTag("correlation.id", correlationId);

        await _next(context);
    }
}

/// <summary>
/// Minimal API responses currently do not carry a server-timing header; this adds
/// the elapsed time of the request, which is the cheapest useful signal for the
/// health of each endpoint.
/// </summary>
public sealed class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            await _next(context);
        }
        finally
        {
            stopwatch.Stop();
            context.Response.Headers["Server-Timing"] = $"app;dur={stopwatch.Elapsed.TotalMilliseconds:F1}";

            var level = stopwatch.ElapsedMilliseconds > 1000 ? LogLevel.Warning : LogLevel.Information;

            _logger.Log(
                level,
                "{Method} {Path} responded {StatusCode} in {ElapsedMs}ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);
        }
    }
}