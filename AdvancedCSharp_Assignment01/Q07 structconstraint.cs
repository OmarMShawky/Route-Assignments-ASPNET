using System;
using System.Collections.Generic;
using System.Text;

namespace Generics;

public struct Money
{
    public decimal Amount { get; }
    public Money(decimal a) => Amount = a;
    public override string ToString() => $"{Amount:C}";
}

public class ValueBox<T> where T : struct
{
    private T? _value;

    public void Set(T v) => _value = v;
    public T Get() => _value ?? default;
    public bool HasValue => _value.HasValue;
}