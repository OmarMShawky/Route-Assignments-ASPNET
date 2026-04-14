using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question1
{
    public static void Answer()
    {
        var products = GetData.ProductList();

        Console.WriteLine("========== Question 1 ==========");
        var result = products
            .Where(c => c.Category == "SeaFood");

        result.Print();
    }
}
