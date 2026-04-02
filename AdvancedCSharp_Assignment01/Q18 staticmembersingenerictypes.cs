using System;
using System.Collections.Generic;
using System.Text;
using Generics;

// Q18
// Each closed generic type (Counter<int>, Counter<string>) gets its OWN
// copy of static members — they are NOT shared across type arguments
// Counter<int> and Counter<string> are separate types at runtime

namespace Q18_StaticMembersInGenericTypes;

public class Counter<T>
{
    private static int _count = 0;

    public Counter() => _count++;

    public static int GetCount() => _count;

    public static void Reset() => _count = 0;
}

// ── Demonstrates per-closed-type isolation ────────────────────
public static class StaticMembersDemo
{
    public static void Run()
    {
        new Counter<int>();
        new Counter<int>();
        new Counter<string>();

        // Each type argument has its OWN static field
        int intCount = Counter<int>.GetCount();    // 2
        int stringCount = Counter<string>.GetCount(); // 1

        // Counter<int>._count and Counter<string>._count are completely separate
        _ = intCount;
        _ = stringCount;
    }
}