using System;
using System.Collections.Generic;
using System.Text;

using Generics;

// Q13 — The 'default' keyword in generics.
// Cannot write null (might be value type) or 0 (might be reference type).
// default(T) returns the "zero" value for any type:
//   reference types  → null
//   value types      → 0 / false / empty struct

public class Container<T>
{
    private T? _value;
    private bool _hasValue;

    public void Set(T v)
    {
        _value = v;
        _hasValue = true;
    }

    // Returns stored value, or default(T) if nothing was ever Set()
    public T GetOrDefault() => _hasValue ? _value! : default(T)!;

    public void Clear()
    {
        _value = default;   // C# 7.1+ shorthand — type inferred from field
        _hasValue = false;
    }
}