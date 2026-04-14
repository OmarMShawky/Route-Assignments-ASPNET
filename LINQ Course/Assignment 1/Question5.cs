using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question5
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 5 ==========");

        var products = GetData.ProductList();

        var result = products
            .Where(u => u.UnitsInStock > 0);


        result.Print();
    }
}
