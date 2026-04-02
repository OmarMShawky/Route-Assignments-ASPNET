using System;
using System.Collections.Generic;
using System.Text;
using Generics;

// Q19
// Three patterns:
//   1. Concrete   — close T at the subclass level  (class IntList : List<int>)
//   2. Pass-through — keep T open                  (class MyList<T> : List<T>)
//   3. Constrained  — add where clauses as you pass T through

namespace Q19_InheritingFromGenericClass;

// ── Base generic class ────────────────────────────────────────
public class BaseRepo<T>
{
    protected List<T> _data = new();

    public virtual void Add(T item) => _data.Add(item);
    public IReadOnlyList<T> GetAll() => _data;
}

// ── Pattern 1: Concrete — T fixed to Customer ─────────────────
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class CustomerRepo : BaseRepo<Customer>
{
    public Customer? FindByName(string name)
        => _data.FirstOrDefault(c => c.Name == name);
}

// ── Pattern 2: Pass-through — T stays open ────────────────────
public class AuditedRepo<T> : BaseRepo<T>
{
    public override void Add(T item)
    {
        Console.WriteLine($"[Audit] Adding {typeof(T).Name}");
        base.Add(item);
    }
}

// ── Pattern 3: Constrained — T narrowed with where ───────────
public abstract class BaseEntity
{
    public int Id { get; set; }
}

public class EntityRepo<T> : BaseRepo<T> where T : BaseEntity
{
    public T? FindById(int id)
        => _data.FirstOrDefault(e => e.Id == id);
}