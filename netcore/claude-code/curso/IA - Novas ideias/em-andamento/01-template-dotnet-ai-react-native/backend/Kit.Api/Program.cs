using System.Text;
using System.Threading.RateLimiting;
using Kit.Api.Contracts;
using Kit.Api.Endpoints;
using Kit.Api.Health;
using Kit.Api.Middleware;
using Kit.Api.Security;
using Kit.Application;
using Kit.CrossCutting;
using Kit.CrossCutting.FeatureFlags;
using Kit.CrossCutting.Time;
using Kit.Domain.Abstractions;
using Kit.Domain.Modules.Identity;
using Kit.Infrastructure;
using Kit.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
// Swashbuckle 10 is built on Microsoft.OpenApi 2.x, where the document models
// live directly in the Microsoft.OpenApi namespace (there is no .Models child).
using Microsoft.OpenApi;
using Prometheus;
using Serilog;
using Serilog.Events;

// ---------------------------------------------------------------------------
// 1. Bootstrap logging BEFORE the host exists, so configuration failures and
//    DI resolution failures are still captured. Console sink first (always
//    available, including inside a container), enrichers afterwards.
// ---------------------------------------------------------------------------
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
    .MinimumLevel.Override("Confluent.Kafka", LogEventLevel.Error)
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", "Kit.Api")
        .WriteTo.Console(outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"));

    // ------------------------------------------------------------------------
    // 2. Configuration validation. Every secret is resolved from configuration
    //    (appsettings for non-secret defaults, environment variables or
    //    user-secrets for secrets). Fail fast here: an API that starts and only
    //    then rejects tokens is worse than one that refuses to start.
    // ------------------------------------------------------------------------
    var jwtSection = builder.Configuration.GetSection(JwtOptions.SectionName);
    var jwtOptions = jwtSection.Get<JwtOptions>() ?? new JwtOptions();

    var signingKey = ResolveSigningKey(builder, jwtOptions);
    var corsOptions = builder.Configuration.GetSection(CORSOptions.SectionName).Get<CORSOptions>() ?? new CORSOptions();

    builder.Logging.ClearProviders();

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddProblemDetails();

    // ------------------------------------------------------------------------
    // 3. Layers: CrossCutting -> Application (ports + CQRS) -> Infrastructure
    //    (adapters). Kit.Api never registers a DbContext or a repository itself.
    // ------------------------------------------------------------------------
    builder.Services.AddCrossCutting(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);

    builder.Services.AddScoped<ICurrentUser, HttpContextCurrentUser>();

    // ------------------------------------------------------------------------
    // 4. Authentication. Symmetric HS256 with a key that came from
    //    configuration. Clock skew is deliberately small, and validation is
    //    strict: wrong issuer, wrong audience or wrong lifetime all fail.
    // ------------------------------------------------------------------------
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.MapInboundClaims = false;
            options.RequireHttpsMetadata = builder.Environment.IsProduction();
            options.SaveToken = false;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30)
            };

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    var logger = context.HttpContext.RequestServices
                        .GetRequiredService<ILoggerFactory>()
                        .CreateLogger("Kit.Api.Jwt");

                    logger.LogWarning("Falha na autenticacao do token: {Reason}", context.Exception.Message);
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    // Default challenge writes an empty body. A client that cannot
                    // tell "no token" from "bad token" from "expired token" is
                    // impossible to debug, so the same Problem Details shape used
                    // everywhere else is produced here too.
                    if (context.AuthenticateFailure is not null)
                    {
                        context.HandleResponse();

                        var payload = new ApiErrorResponse(
                            Type: "https://httpstatuses.io/401",
                            Title: "Unauthorized",
                            Status: StatusCodes.Status401Unauthorized,
                            Code: "auth.token-invalid",
                            Detail: "Token ausente, invalido ou expirado.",
                            TraceId: context.HttpContext.TraceIdentifier);

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/problem+json";

                        return context.Response.WriteAsJsonAsync(payload);
                    }

                    return Task.CompletedTask;
                }
            };
        });

    // ------------------------------------------------------------------------
    // 5. Authorization. One policy per permission in the catalog: an endpoint
    //    names a permission, never a role. Roles change, permissions are stable.
    // ------------------------------------------------------------------------
    builder.Services.AddAuthorization(options => options.AddPermissionPolicies());

    // ------------------------------------------------------------------------
    // 6. Transport concerns.
    // ------------------------------------------------------------------------
    var allowedOrigins = corsOptions.AllowedOrigins
        .Where(origin => !string.IsNullOrWhiteSpace(origin))
        .Select(origin => origin.Trim())
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToArray();

    const string CorsPolicy = "kit-web";

    builder.Services.AddCors(options => options.AddPolicy(CorsPolicy, policy => policy
        .WithOrigins(allowedOrigins)
        .AllowAnyHeader()
        .AllowAnyMethod()
        // Credentials are what make the Authorization header usable from a
        // browser. Combined with an explicit origin allow-list, never with
        // AllowAnyOrigin + credentials, which the browser rejects anyway.
        .AllowCredentials()
        .WithExposedHeaders("X-Correlation-Id", "Server-Timing")));

    builder.Services.AddRateLimiter(options =>
    {
        // Global safety net against brute-force and traffic spikes.
        options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
            RateLimitPartition.GetFixedWindowLimiter(
                context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 300,
                    Window = TimeSpan.FromMinutes(1),
                    QueueLimit = 0
                }));

        // Login is far more expensive (BCrypt) and far more attractive to an
        // attacker than a normal read, so it gets its own, much tighter budget.
        options.AddPolicy("login", httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(
                httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = 10,
                    Window = TimeSpan.FromMinutes(1),
                    QueueLimit = 0
                }));
    });

    // Behind a reverse proxy the client IP arrives in a header; without this the
    // rate limiter would bucket every caller together.
    builder.Services.Configure<ForwardedHeadersOptions>(options =>
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        options.KnownIPNetworks.Clear();
        options.KnownProxies.Clear();
    });

    builder.Services.AddHealthChecks()
        .AddCheck<DatabaseHealthCheck>("mysql", tags: ["ready"]);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Kit API",
            Version = "v1",
            Description = "Boundary HTTP do Modular Monolith. Autorizacao por permissao do catalogo IAM."
        });

        // Bearer is declared here so the Swagger UI can send "Authorize" without
        // the developer pasting a token into every request by hand.
        // Microsoft.OpenApi 2.x keys a requirement by an *identifier* object
        // (OpenApiSecuritySchemeReference), not by an inline scheme definition.
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Informe apenas o token de acesso. Ele e obtido em POST /api/auth/login."
        });

        options.AddSecurityRequirement(_ => new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer")] = []
        });
    });

    var app = builder.Build();

    // ------------------------------------------------------------------------
    // 7. Pipeline order is deliberate and load-bearing:
    //    correlation -> exception -> proxy -> cors -> rate limit ->
    //    swagger -> authentication -> authorization -> endpoints.
    // ------------------------------------------------------------------------
    app.UseForwardedHeaders();
    app.UseSerilogRequestLogging(options =>
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
            diagnosticContext.Set("CorrelationId", httpContext.TraceIdentifier));

    app.UseMiddleware<CorrelationIdMiddleware>();
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseMiddleware<RequestTimingMiddleware>();

    app.UseCors(CorsPolicy);

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Kit API v1"));
    }

    app.UseRateLimiter();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapHealthEndpoints();
    app.MapAuthEndpoints();
    app.MapReadEndpoints(app.Services.GetRequiredService<IFeatureFlagReader>());

    // Prometheus scrape endpoint. Left anonymous but on its own path; if it must
    // be locked down, do it at the ingress, not by guessing networks here.
    app.MapMetrics("/metrics");

    app.Logger.LogInformation(
        "Kit.Api iniciado em {Environment}. Origens CORS: {Origins}. Seed: {SeedEnabled}.",
        app.Environment.EnvironmentName,
        allowedOrigins.Length == 0 ? "(nenhuma)" : string.Join(", ", allowedOrigins),
        builder.Configuration.GetValue<bool>($"{SeedOptions.SectionName}:Enabled"));

    await app.RunAsync();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Kit.Api terminou com uma falha irrecuperavel durante a inicializacao.");
    throw;
}
finally
{
    await Log.CloseAndFlushAsync();
}

// Resolves the JWT signing key and refuses to continue without a strong one.
//
// The minimum length is enforced because HS256 with a short key is brute
// forceable, and a token signed with a guessable key is worse than no auth at
// all: it looks authenticated.
static string ResolveSigningKey(WebApplicationBuilder builder, JwtOptions options)
{
    var key = options.SigningKey
              ?? builder.Configuration["Jwt:SigningKey"]
              ?? builder.Configuration["JWT_SIGNING_KEY"];

    if (string.IsNullOrWhiteSpace(key))
    {
        throw new InvalidOperationException(
            "Jwt:SigningKey nao configurada. Informe a variavel de ambiente JWT__SigningKey " +
            "(ou dotnet user-secrets set \"Jwt:SigningKey\") com ao menos 32 caracteres.");
    }

    if (key.Length < 32)
    {
        throw new InvalidOperationException(
            $"Jwt:SigningKey tem apenas {key.Length} caracteres. Use no minimo 32: " +
            "uma chave curta torna o token falsificavel por forca bruta.");
    }

    return key;
}

// Exposed so the integration test host (WebApplicationFactory) can reference the
// entry point assembly of this top-level-statements program.
public partial class Program;