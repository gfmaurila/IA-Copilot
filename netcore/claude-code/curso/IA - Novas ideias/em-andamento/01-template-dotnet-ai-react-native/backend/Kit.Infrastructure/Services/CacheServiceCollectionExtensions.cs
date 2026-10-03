using Kit.Application.Abstractions.Security;
using Kit.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kit.Infrastructure.Services;

public static class CacheServiceCollectionExtensions
{
    /// <summary>
    /// Registers the caching abstraction twice on purpose:
    ///  - <c>ICacheService</c> is the Application PORT (business code depends on this);
    ///  - <c>IDistributedCache</c> is the Infrastructure detail.
    /// When Redis is disabled a memory cache is used, so a developer needs no Docker
    /// to run the solution - and the production behaviour is identical through the port.
    /// </summary>
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        var redisOptions = configuration.GetSection(RedisOptions.SectionName).Get<RedisOptions>()
            ?? new RedisOptions();

        if (redisOptions.Enabled && !string.IsNullOrWhiteSpace(redisOptions.ConnectionString))
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisOptions.ConnectionString;
                options.InstanceName = redisOptions.InstanceName;
            });
        }
        else
        {
            // AddDistributedMemoryCache, NOT AddMemoryCache: CacheService depends on
            // IDistributedCache, and AddMemoryCache only registers IMemoryCache.
            // Using the wrong one here compiles fine and fails at runtime with
            // "Unable to resolve service for type IDistributedCache".
            services.AddDistributedMemoryCache();
        }

        services.AddScoped<ICacheService, CacheService>();
        return services;
    }
}