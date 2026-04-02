using System;
using System.Collections.Generic;
using System.Text;

namespace Generics;

// 'new()' constraint.
// Guarantees T has a public parameterless constructor,
// so generic code can call new T() to create instances

public class ObjectFactory<T> where T : new()
{
    public static T CreateAndInit<T>() where T : new()
    {
        return new T();
    }
    public T Create() => new T();

    public List<T> CreateMany(int count)
        => Enumerable.Range(0, count)
                     .Select(_ => new T())
                     .ToList();
}