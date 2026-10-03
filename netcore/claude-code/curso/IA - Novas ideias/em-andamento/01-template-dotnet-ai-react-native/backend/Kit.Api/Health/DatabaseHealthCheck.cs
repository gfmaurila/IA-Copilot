using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Kit.Api.Health;

/// <summary>
/// Readiness probe for MySQL.
///
/// It opens a real connection instead of trusting a configuration flag: a
/// container that is running but cannot reach its database must be reported as
/// NOT ready, otherwise traffic keeps being routed to a broken instance.
///
/// It is deliberately tolerant about timing. A probe that hangs for 30 seconds
/// is worse than one that fails fast, so the check carries its own short timeout.
/// </summary>
public sealed class DatabaseHealthCheck : IHealthCheck
{
    private static readonly TimeSpan ProbeTimeout = TimeSpan.FromSeconds(5);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<DatabaseHealthCheck> _logger;

    public DatabaseHealthCheck(IServiceScopeFactory scopeFactory, ILogger<DatabaseHealthCheck> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        using var timeoutSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutSource.CancelAfter(ProbeTimeout);

        try
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider
                .GetRequiredService<Kit.Infrastructure.Persistence.Context.KitDbContext>();

            if (!await dbContext.Database.CanConnectAsync(timeoutSource.Token))
            {
                return HealthCheckResult.Unhealthy("MySQL respondeu que a conexao nao pode ser aberta.");
            }

            // A real round-trip is the only way to prove the schema is reachable
            // and the credentials are accepted, not just that a socket opened.
            var connection = dbContext.Database.GetDbConnection();
            await connection.OpenAsync(timeoutSource.Token);

            var serverVersion = connection.ServerVersion;

            await connection.CloseAsync();

            return HealthCheckResult.Healthy(
                $"MySQL {serverVersion} acessivel.",
                new Dictionary<string, object> { ["serverVersion"] = serverVersion });
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogWarning("Health check do MySQL excedeu {Timeout}s", ProbeTimeout.TotalSeconds);
            return HealthCheckResult.Unhealthy($"MySQL nao respondeu em {ProbeTimeout.TotalSeconds:F0}s.");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Health check do MySQL falhou");
            return HealthCheckResult.Unhealthy("Falha ao acessar o MySQL.", exception);
        }
    }
}