using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question6
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 6 ==========");

        var products = GetData.ProductList();

        var result = products.Select(p => new
        {
            p.Name,
            p.Price,
            StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
        });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} \t {item.Price} \t {item.StockStatus}");
        }

    }
}
