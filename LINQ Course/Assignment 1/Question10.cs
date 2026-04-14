using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question10
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 10 ==========");
        List<Customer> customers = GetData.CustomerList();

        var result = from c in customers
                     from o in c.Orders
                     where o.OrderDate.Year >= 1997
                     select new
                     {
                         c.CustomerID,
                         o.OrderDate
                     };


        foreach (var item in result)
        {
            Console.WriteLine($"  {item.CustomerID} | {item.OrderDate:dd-MM-yyyy}");
        }
    }

}
