using System;
using System.Collections.Generic;
using System.Text;
using Generics;

// Q20
// Combines: multiple type parameters, notnull constraint, default keyword
// record types, and real-world TTL (time-to-live) eviction logic

namespace Q20_CacheExercise;

public class Cache<TKey, TValue> where TKey : notnull
{
    // Private record to bundle the value with its expiry timestamp
    private record CacheEntry(TValue Value, DateTime ExpiresAt);

    private readonly Dictionary<TKey, CacheEntry> _store = new();
    private readonly TimeSpan _ttl;

    // Default TTL: 5 minutes. Caller can override.
    public Cache(TimeSpan? ttl = null) => _ttl = ttl ?? TimeSpan.FromMinutes(5);

    // ── Write ─────────────────────────────────────────────────
    public void Add(TKey key, TValue value)
    {
        _store[key] = new CacheEntry(value, DateTime.UtcNow + _ttl);
    }

    // ── Read ──────────────────────────────────────────────────
    // Returns default(TValue) if key is missing or expired.
    public TValue? Get(TKey key)
    {
        if (!_store.TryGetValue(key, out var entry))
            return default;

        if (DateTime.UtcNow > entry.ExpiresAt)
        {
            _store.Remove(key);   // lazy eviction on read
            return default;
        }

        return entry.Value;
    }

    // ── Delete ────────────────────────────────────────────────
    public void Remove(TKey key) => _store.Remove(key);

    // ── Query ─────────────────────────────────────────────────
    // Returns true only if the key exists AND is not yet expired.
    public bool Contains(TKey key)
        => _store.TryGetValue(key, out var entry)
        && DateTime.UtcNow <= entry.ExpiresAt;

    // ── Maintenance ───────────────────────────────────────────
    // Proactively removes all expired entries (call periodically if needed).
    public void Purge()
    {
        var expired = _store
            .Where(kv => DateTime.UtcNow > kv.Value.ExpiresAt)
            .Select(kv => kv.Key)
            .ToList();

        foreach (var key in expired)
            _store.Remove(key);
    }

    public int Count => _store.Count;
}