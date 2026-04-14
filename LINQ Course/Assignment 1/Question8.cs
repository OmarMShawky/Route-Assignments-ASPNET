using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question8
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 8 ==========");
        var products = GetData.ProductList();

        var result = products
            .OrderBy(c => c.Category)
            .ThenByDescending(p => p.Price);

        result.Print();

    }
}
