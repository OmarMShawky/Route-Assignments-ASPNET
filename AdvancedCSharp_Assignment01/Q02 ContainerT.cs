using System;
using System.Collections.Generic;
using System.Text;

namespace Generics;

public class Container<T>
{
    private T _variable;
    public void Add(T variable)
    {
        _variable = variable;
    }

    public T Get()
    {
        return _variable;
    }
}