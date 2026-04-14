using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question11
{
    public static void Answer()
    {
        Console.WriteLine("=== Exercise 11: ===\n");

        List<Product> products = GetData.ProductList();

        var result = products.Select((p, index) => new
        {
            Position = index + 1, // because index begins with 0
            p.Name
        });


        foreach (var item in result)
        {
            Console.WriteLine($"  {item.Position,3}. {item.Name}");
        }
    }
}
