// Q01 — What is a generic class? Why use generics?
// A generic class is parameterized over a type T.
// Benefits: type safety, code reuse, no boxing for value types.

namespace Generics;

// Without generics — loses type info, risks InvalidCastException
public class ObjectBox
{
    private object? _value;
    public void Set(object value) => _value = value;
    public object? Get() => _value;
}

// With generics — fully type-safe, no cast needed at call site
public class GenericBox<T>
{
    private T? _value;
    public void Set(T value) => _value = value;
    public T? Get() => _value;
}