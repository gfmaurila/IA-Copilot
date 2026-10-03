using Kit.Application.Abstractions.Repositories;
using Kit.Application.Abstractions.Security;
using Kit.CrossCutting.Time;
using Kit.Domain.Abstractions;
using Kit.Infrastructure.Options;
using Kit.Infrastructure.Persistence;
using Kit.Infrastructure.Persistence.Context;
using Kit.Infrastructure.Persistence.Repositories.Content;
using Kit.Infrastructure.Persistence.Repositories.Identity;
using Kit.Infrastructure.Persistence.Repositories.Modules;
using Kit.Infrastructure.Persistence.Seeding;
using Kit.Infrastructure.Security;
using Kit.Infrastructure.Services;
using Kit.Producer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kit.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    /// <summary>
    /// Composition root of the Modular Monolith: this is the only place where the
    /// Application PORTS are bound to concrete Infrastructure implementations.
    /// Kit.Api only calls this method; it never registers a DbContext or a repository.
    /// </summary>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services.AddOptions();
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
        services.Configure<RedisOptions>(configuration.GetSection(RedisOptions.SectionName));
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
        services.Configure<SeedOptions>(configuration.GetSection(SeedOptions.SectionName));
        services.Configure<AiOptions>(configuration.GetSection(AiOptions.SectionName));
        services.Configure<MessagingOptions>(configuration.GetSection(MessagingOptions.SectionName));
        services.Configure<CORSOptions>(configuration.GetSection(CORSOptions.SectionName));

        var databaseOptions = configuration.GetSection(DatabaseOptions.SectionName).Get<DatabaseOptions>()
            ?? new DatabaseOptions();

        services.AddDbContext<KitDbContext>(options =>
        {
            options.UseMySQL(
                databaseOptions.BuildConnectionString(),
                mysql =>
                {
                    if (databaseOptions.EnableRetryOnFailure)
                    {
                        mysql.EnableRetryOnFailure(databaseOptions.MaxRetryCount, TimeSpan.FromSeconds(5), null);
                    }
                    mysql.CommandTimeout(databaseOptions.CommandTimeoutSeconds);
                    mysql.MigrationsAssembly(typeof(InfrastructureServiceCollectionExtensions).Assembly.FullName);
                });

            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        });

        // Ambiguity guard: Kit.Application MUST never see a DbContext. This check is
        // cheap and turns a silent layering violation into an immediate failure.
        AssertApplicationIsPersistenceFree(services);

        services.AddSingleton<IClock, SystemClock>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDomainEventPublisher, Messaging.DomainEventPublisher>();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IContentTypeRepository, ContentTypeRepository>();
        services.AddScoped<IContentItemRepository, ContentItemRepository>();
        services.AddScoped<ITaxonomyRepository, TaxonomyRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IMediaItemRepository, MediaItemRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IAuditEntryRepository, AuditEntryRepository>();
        services.AddScoped<IAiAgentRepository, AiAgentRepository>();
        services.AddScoped<IAiToolDefinitionRepository, AiToolDefinitionRepository>();
        services.AddScoped<AgentExecutionRepository>();
        services.AddScoped<KnowledgeBaseRepository>();

        // Security
        services.AddSingleton<IPasswordHasher, BcryptPasswordHasher>();
        services.AddSingleton<ITokenService, JwtTokenService>();
        services.AddScoped<IUserPermissionReader, UserPermissionReader>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();

        // Cache
        services.AddCache(configuration);

        // Messaging: the Kafka bridge is opt-in. With messaging disabled the
        // publisher logs the events and the in-process monolith stays authoritative.
        var messagingOptions = configuration.GetSection(MessagingOptions.SectionName).Get<MessagingOptions>()
            ?? new MessagingOptions();

        if (messagingOptions.Enabled && !string.IsNullOrWhiteSpace(messagingOptions.BootstrapServers))
        {
            services.AddSingleton<IEventProducer>(provider => new KafkaEventProducer(
                messagingOptions.BootstrapServers!,
                messagingOptions.TopicPrefix,
                provider.GetRequiredService<ILogger<KafkaEventProducer>>()));
        }
        else
        {
            services.AddSingleton<IEventProducer, NullEventProducer>();
        }

        // Startup seeding. Registered as a hosted service so it runs AFTER the
        // container is fully built (and therefore after logging is configured) and
        // BEFORE the API starts accepting traffic.
        services.AddHostedService<DatabaseSeeder>();

        return services;
    }

    /// <summary>
    /// Fails fast if a DbContext or EF Core type ever leaks into the Application
    /// container. Kept as an explicit test because the layering rule is the single
    /// most expensive thing to break in a Modular Monolith.
    /// </summary>
    private static void AssertApplicationIsPersistenceFree(IServiceCollection services)
    {
        var offenders = services
            .Where(descriptor =>
                descriptor.ServiceType.Namespace?.StartsWith("Kit.Application", StringComparison.Ordinal) == true)
            .Select(descriptor => descriptor.ServiceType.FullName)
            .ToList();

        // Application descriptors registered so far are validators/handlers; only a
        // DbContext or a repository implementation would be a violation.
        var violations = offenders
            .Where(name => name!.Contains("DbContext", StringComparison.Ordinal)
                        || name!.Contains("Repository", StringComparison.Ordinal))
            .ToList();

        if (violations.Count > 0)
        {
            throw new InvalidOperationException(
                "Violação de camada: " + string.Join(", ", violations) +
                " foi registrado a partir de Kit.Application. A camada Application não pode conhecer EF Core.");
        }
    }
}