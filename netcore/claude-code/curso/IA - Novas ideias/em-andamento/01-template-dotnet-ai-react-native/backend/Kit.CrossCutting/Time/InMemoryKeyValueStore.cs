using System.Collections.Concurrent;

namespace Kit.CrossCutting.Time;

/// <summary>
/// Bounded in-memory registry used by Infrastructure when no Redis instance is
/// configured, so the application stays runnable in Minimal mode without a cache.
/// </summary>
public sealed class InMemoryKeyValueStore
{
    private readonly ConcurrentDictionary<string, (object Value, DateTimeOffset? ExpiresAt)> _store = new();

    public void Set(string key, object value, TimeSpan? ttl = null)
        => _store[key] = (value, ttl is null ? null : DateTimeOffset.UtcNow.Add(ttl.Value));

    public bool TryGet<T>(string key, out T? value)
    {
        if (_store.TryGetValue(key, out var entry))
        {
            if (entry.ExpiresAt is null || entry.ExpiresAt > DateTimeOffset.UtcNow)
            {
                value = (T)entry.Value;
                return true;
            }

            _store.TryRemove(key, out _);
        }

        value = default;
        return false;
    }

    public void Remove(string key) => _store.TryRemove(key, out _);

    public void Clear() => _store.Clear();
}