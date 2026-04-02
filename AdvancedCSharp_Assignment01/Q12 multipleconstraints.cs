using System;
using System.Collections.Generic;
using System.Text;

using Generics;
namespace Q12_multipleconstraints;
// Q12
// All conditions must be satisfied simultaneously
// Order: base class first, then interfaces, then new() last

// Re-use types from earlier questions inline (no cross-namespace dependency)
public abstract class BaseEntity
{
    public int Id { get; set; }
    public string Describe()
    {
        return $"Entity #{Id}";
    }
}

public interface IPrintable
{
    void Print();
}

// ── T must extend BaseEntity, implement IPrintable, and have new() ───
public class EntityService<T>
    where T : BaseEntity, IPrintable, new()
{
    public T CreateAndLog()
    {
        var entity = new T();    // new() allows this
        entity.Print();          // IPrintable allows this
        return entity;
    }
}

// ── Multiple type parameters can each have separate constraints ───────
public class Map<TKey, TValue>
    where TKey : IComparable<TKey>
    where TValue : class, new()
{
    private readonly Dictionary<TKey, TValue> _inner = new();
    public void Add(TKey key) => _inner[key] = new TValue();
}