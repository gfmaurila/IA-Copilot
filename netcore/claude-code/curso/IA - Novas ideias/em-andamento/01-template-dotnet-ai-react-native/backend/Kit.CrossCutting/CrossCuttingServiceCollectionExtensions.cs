using Kit.CrossCutting.FeatureFlags;
using Kit.CrossCutting.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kit.CrossCutting;

public static class CrossCuttingServiceCollectionExtensions
{
    /// <summary>
    /// Registers cross-cutting concerns shared by every host (Api, Consumer,
    /// Producer). No module-specific registration happens here.
    /// </summary>
    public static IServiceCollection AddCrossCutting(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FeatureFlagsOptions>(configuration.GetSection(FeatureFlagsOptions.SectionName));

        services.AddSingleton<ICorrelationIdAccessor, CorrelationIdAccessor>();
        services.AddScoped<IRequestContextAccessor, RequestContextAccessor>();
        services.AddSingleton<IFeatureFlagReader, FeatureFlagReader>();
        services.AddSingleton<InMemoryKeyValueStore>();

        return services;
    }
}