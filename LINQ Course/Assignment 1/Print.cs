using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public static class Extension
{
    public static void Print<T>(this IEnumerable<T> values)
    {
        foreach (var product in values)
        {
            Console.WriteLine(product);
        }
        
    }
}
