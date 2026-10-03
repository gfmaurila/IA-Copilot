using Kit.Application.Abstractions.Security;
using Kit.Infrastructure.Options;
using Kit.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Kit.Infrastructure.Persistence.Seeding;

/// <summary>
/// Runs the seed pipeline on startup.
///
/// SAFETY RULES (these are not configurable away):
///  - a seeder NEVER runs when Seed:Enabled is false;
///  - Demo/Stress NEVER run in Production, even if enabled by mistake;
///  - the demo password MUST come from configuration (env / user-secrets). If it is
///    missing the seeder refuses to create accounts rather than falling back to a
///    well-known default that would end up in production.
/// </summary>
public sealed class DatabaseSeeder : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly SeedOptions _options;
    private readonly DatabaseOptions _databaseOptions;
    private readonly IHostEnvironment _environment;
    private readonly ILogger<DatabaseSeeder> _logger;

    public DatabaseSeeder(
        IServiceProvider serviceProvider,
        IOptions<SeedOptions> options,
        IOptions<DatabaseOptions> databaseOptions,
        IHostEnvironment environment,
        ILogger<DatabaseSeeder> logger)
    {
        _serviceProvider = serviceProvider;
        _options = options.Value;
        _databaseOptions = databaseOptions.Value;
        _environment = environment;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (!_options.Enabled)
        {
            _logger.LogInformation("Seeding disabled (Seed:Enabled=false)");
            return;
        }

        var mode = (_options.Mode ?? "Minimal").Trim();

        if (mode.Equals("None", StringComparison.OrdinalIgnoreCase))
        {
            _logger.LogInformation("Seeding skipped (Seed:Mode=None)");
            return;
        }

        if (!IsMinimalMode(mode))
        {
            _logger.LogWarning(
                "Seed mode '{Mode}' is not allowed in Production. Only Minimal is permitted. Skipping.",
                mode);
            return;
        }

        // Seeding writes rows into tables that must already exist. Whether the host
        // is allowed to create them is Database:AutoMigrate, NOT the seeding flag:
        // auto-migrating in Production is an accident waiting to happen.
        if (!_databaseOptions.AutoMigrate)
        {
            _logger.LogWarning(
                "Database:AutoMigrate is false, so pending migrations will not be applied. " +
                "Seeding is skipped to avoid writing into a schema that may be out of date. " +
                "Apply migrations explicitly (dotnet ef database update) or enable Database:AutoMigrate in Development.");
            return;
        }

        await using var scope = _serviceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<KitDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        var demoPassword = _options.DemoUserPassword;

        if (string.IsNullOrWhiteSpace(demoPassword))
        {
            _logger.LogError(
                "Seed:DemoUserPassword is not configured. Refusing to create demo accounts with an unknown password. " +
                "Set the variable Seed__DemoUserPassword (or Seed:DemoUserPassword) before starting the API.");
            return;
        }

        _logger.LogInformation("Applying migrations before seeding ({Mode})", mode);
        await context.Database.MigrateAsync(cancellationToken);

        await IdentityDataSeeder.SeedAsync(context, passwordHasher, demoPassword, cancellationToken);
        await ContentDataSeeder.SeedAsync(context, cancellationToken);
        await NavigationDataSeeder.SeedAsync(context, cancellationToken);
        await AiDataSeeder.SeedAsync(context, cancellationToken);

        if (mode.Equals("Demo", StringComparison.OrdinalIgnoreCase) || mode.Equals("Stress", StringComparison.OrdinalIgnoreCase))
        {
            await DemoDataSeeder.SeedAsync(
                context,
                passwordHasher,
                demoPassword,
                _options.RandomSeed,
                mode,
                cancellationToken);
        }

        _logger.LogInformation("Seeding completed in mode {Mode}", mode);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private static bool IsMinimalMode(string mode) => mode.Equals("Minimal", StringComparison.OrdinalIgnoreCase);
}