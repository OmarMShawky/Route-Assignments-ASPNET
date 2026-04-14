using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question7
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 7 ==========");
        var products = GetData.ProductList();

        var result = products
            .Select(product => product.Name);

        int i = 1;
        foreach(var item in result)
        {
            Console.WriteLine($"{i}. {item}");
            i++;
        }
    }
}
