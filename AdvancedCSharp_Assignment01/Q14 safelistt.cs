using System;
using System.Collections.Generic;
using System.Text;

using Generics;

// Q14 — SafeList<T>: returns default(T) instead of throwing on invalid index.
// Practical use of the default keyword — graceful degradation instead of
// IndexOutOfRangeException (useful in statement processing pipelines).

public class SafeList<T>
{
    private readonly List<T> _inner = new();

    public void Add(T item) => _inner.Add(item);
    public int Count => _inner.Count;

    public T? this[int index]
    {
        get
        {
            if (index < 0 || index >= _inner.Count)
                return default(T); // null for classes, 0 for int, false for bool, etc.

            return _inner[index];
        }
    }
}
