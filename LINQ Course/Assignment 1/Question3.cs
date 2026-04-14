using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question3
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 3 ==========");
        var products = GetData.ProductList();

        var result = products
            .OrderBy(p => p.Price);

        result.Print();

    }
}
