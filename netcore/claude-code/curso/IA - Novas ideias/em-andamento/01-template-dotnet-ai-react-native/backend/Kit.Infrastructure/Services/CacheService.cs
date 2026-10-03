using System.Text.Json;
using Kit.Application.Abstractions.Security;
using Microsoft.Extensions.Caching.Distributed;

namespace Kit.Infrastructure.Services;

/// <summary>
/// Application-level cache PORT implemented on top of the registered
/// <see cref="IDistributedCache"/> (Redis when enabled, otherwise the in-process
/// distributed memory cache).
///
/// Keys are namespaced with an InstanceName so two environments sharing one Redis
/// can never read each other's entries. Values are JSON serialized, which keeps the
/// cached shape stable and avoids accidental in-process object graphs leaking
/// across requests.
/// </summary>
public sealed class CacheService : ICacheService
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache) => _cache = cache;

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var value = await _cache.GetStringAsync(BuildKey(key), cancellationToken);

        if (value is null)
        {
            return default;
        }

        try
        {
            return JsonSerializer.Deserialize<T>(value, SerializerOptions);
        }
        catch (JsonException)
        {
            // A malformed entry must not take the request down: treat it as a miss.
            await _cache.RemoveAsync(BuildKey(key), cancellationToken);
            return default;
        }
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? ttl = null, CancellationToken cancellationToken = default)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = ttl ?? TimeSpan.FromMinutes(5)
        };

        return _cache.SetStringAsync(
            BuildKey(key),
            JsonSerializer.Serialize(value, SerializerOptions),
            options,
            cancellationToken);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        => _cache.RemoveAsync(BuildKey(key), cancellationToken);

    /// <summary>
    /// Read-through cache. The factory is only invoked on a miss.
    /// </summary>
    public async Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        TimeSpan? ttl = null,
        CancellationToken cancellationToken = default)
    {
        var cached = await GetAsync<T>(key, cancellationToken);

        if (cached is not null)
        {
            return cached;
        }

        var value = await factory(cancellationToken);
        await SetAsync(key, value, ttl, cancellationToken);
        return value;
    }

    private static string BuildKey(string key) => $"kit:{key.Trim().ToLowerInvariant()}";
}