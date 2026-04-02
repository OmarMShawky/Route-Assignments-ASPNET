using System;
using System.Collections.Generic;
using System.Text;

// Q03 — Multiple type parameters: Pair<TKey, TValue>.
// Each type argument is independently substituted at the call site.

namespace Generics;

public class Pair<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    public Pair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public override string ToString() => $"[{Key}: {Value}]";
}