using System;
using System.Collections.Generic;
using System.Text;

using Generics;

// Q11 — Base class constraint.
// Requires T to be the specified class or a subclass of it.
// Generic code gets access to all base class members directly.

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public abstract string Describe();
}

public class AuditLogger<T> where T : BaseEntity
{
    public void Log(T entity)
    {
        // Id and CreatedAt are accessible — T extends BaseEntity
        Console.WriteLine($"[{entity.CreatedAt:u}] #{entity.Id}: {entity.Describe()}");
    }
}

// ── Sample subclass ───────────────────────────────────────────
public class Account : BaseEntity
{
    public string Holder { get; set; } = string.Empty;
    public override string Describe() => $"Account of {Holder}";
}
