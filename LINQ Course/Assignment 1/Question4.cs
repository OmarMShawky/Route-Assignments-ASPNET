using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

internal class Question4
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 4 ==========");
        var products = GetData.ProductList();

        var result = products
            .Where(p => p.Price >= 10 && p.Price <= 30);

        result.Print();

    }
}
