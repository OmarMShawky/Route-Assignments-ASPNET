using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question9
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 9 ==========");
        var products = GetData.ProductList();

        var result = products
            .Where(c => c.Category == "Beverages")
            .OrderByDescending(u => u.UnitsInStock)
            .Select(p => new { p.Name, p.UnitsInStock })
            .ToList();


        result.Print();
    }
}
