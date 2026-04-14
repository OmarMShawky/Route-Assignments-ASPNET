using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question2
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 2 ==========");
        var products = GetData.ProductList();
        var result = products
            .Select(product => product.Name);

        result.Print();
    }
}
