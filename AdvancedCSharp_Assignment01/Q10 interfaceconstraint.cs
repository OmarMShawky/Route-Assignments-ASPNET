using System;
using System.Collections.Generic;
using System.Text;

namespace Generics;

// Q10 — Interface constraint.
// Requires T to implement a specific interface.
// Generic code can call interface members on T with no casting.


public interface IPrintable
{
    void Print();
}

public class Printer<T> where T : IPrintable
{
    public void PrintAll(IEnumerable<T> items)
    {
        foreach (var item in items)
            item.Print();
    }
}
public class BankStatement : IPrintable
{
    public string AccountNo { get; set; } = string.Empty;
    public void Print() => Console.WriteLine($"Statement: {AccountNo}");
}
