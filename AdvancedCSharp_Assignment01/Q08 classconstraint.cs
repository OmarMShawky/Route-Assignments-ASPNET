using System;
using System.Collections.Generic;
using System.Text;

namespace Generics;

public class NullableWrapper<T> where T : class
{
    private T? _value;

    public void Set(T v) => _value = v;
    public T? Get() => _value;
    public bool IsNull => _value is null;
}