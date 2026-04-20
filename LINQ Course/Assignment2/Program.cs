using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAssignment2;

class Program
{
    // Shortcuts so queries stay clean
    static List<Product>  Products  = DataSet.Products;
    static List<Customer> Customers = DataSet.Customers;
    static List<Order>    Orders    = DataSet.Orders;

    static void Main()
    {
        Console.WriteLine("--- Q1 ---");
        var top3 = Products.OrderByDescending(p => p.UnitPrice).Take(3);
        foreach (var p in top3)
            Console.WriteLine($"{p.ProductName} - ${p.UnitPrice}");

        // ---------- 2. Page 2, page size 5 ----------
        Console.WriteLine("\n--- Q2 ---");
        int pageSize = 5, pageNumber = 2;
        var page2 = Products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        foreach (var p in page2)
            Console.WriteLine($"{p.ProductID}: {p.ProductName}");

        // ---------- 3. TakeWhile UnitPrice < 25 (ordered) ----------
        Console.WriteLine("\n--- Q3 ---");
        var cheap = Products.OrderBy(p => p.UnitPrice)
            .TakeWhile(p => p.UnitPrice < 25);
        foreach (var p in cheap)
            Console.WriteLine($"{p.ProductName} - ${p.UnitPrice}");

        // ---------- 4. All Seafood products in stock? ----------
        Console.WriteLine("\n--- Q4 ---");
        bool allInStock = Products.Where(p => p.Category == "Seafood")
            .All(p => p.UnitsInStock > 0);
        Console.WriteLine($"All Seafood in stock: {allInStock}");

        // ---------- 5. Does the ID list contain 9? ----------
        Console.WriteLine("\n--- Q5 ---");
        int[] ids = { 3, 9, 13, 18 };
        Console.WriteLine($"Contains 9: {ids.Contains(9)}");

        // ---------- 6. Group products by Category with count ----------
        Console.WriteLine("\n--- Q6 ---");
        var byCat = Products.GroupBy(p => p.Category);
        foreach (var g in byCat)
            Console.WriteLine($"{g.Key}: {g.Count()}");

        // ---------- 7. Group by Category, project only names ----------
        Console.WriteLine("\n--- Q7 ---");
        var groups = Products.GroupBy(p => p.Category, p => p.ProductName);
        foreach (var g in groups)
        {
            Console.WriteLine($"{g.Key}:");
            foreach (var name in g)
                Console.WriteLine($"   - {name}");
        }

        // ---------- 8. Categories with MORE THAN 3 products ----------
        Console.WriteLine("\n--- Q8 ---");
        var bigCats = Products.GroupBy(p => p.Category)
            .Where(g => g.Count() > 3)
            .Select(g => new { Category = g.Key, Count = g.Count() });
        foreach (var c in bigCats)
            Console.WriteLine($"{c.Category}: {c.Count}");

        // ---------- 9. Query syntax: customers grouped by Country ----------
        Console.WriteLine("\n--- Q9. ---");
        var byCountry = from c in Customers
            group c by c.Country into g
            select new
            {
                Country = g.Key,
                Count = g.Count(),
                TotalOrderValue = (from cust in g
                    join o in Orders on cust.CustomerID equals o.CustomerID
                    select o.Total).Sum()
            };
        foreach (var x in byCountry)
            Console.WriteLine($"{x.Country} | Count: {x.Count} | Total: ${x.TotalOrderValue}");

        // ---------- 10. Total units in stock ----------
        Console.WriteLine("\n--- Q10.  ---");
        int totalStock = Products.Sum(p => p.UnitsInStock);
        Console.WriteLine($"Total units in stock: {totalStock}");

        // ---------- 11. Cheapest and most expensive ----------
        Console.WriteLine("\n--- Q11. ---");
        decimal min = Products.Min(p => p.UnitPrice);
        decimal max = Products.Max(p => p.UnitPrice);
        Console.WriteLine($"Cheapest: ${min} | Most expensive: ${max}");

        // ---------- 12. Distinct categories ----------
        Console.WriteLine("\n--- Q12. ---");
        var distinctCats = Products.Select(p => p.Category).Distinct();
        foreach (var c in distinctCats)
            Console.WriteLine(c);

        // ---------- 13. setA EXCEPT setB ----------
        Console.WriteLine("\n--- Q13. ---");
        int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
        int[] setB = { 3, 6, 9, 12, 15, 13 };
        var diff = setA.Except(setB);
        Console.WriteLine(string.Join(", ", diff));

        // ---------- 14. Country diff (case-insensitive) ----------
        Console.WriteLine("\n--- Q14. ---");
        string[] list1 = { "Germany", "France", "UK", "Spain" };
        string[] list2 = { "france", "SPAIN", "Italy" };
        var countryDiff = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine(string.Join(", ", countryDiff));

        // ---------- 15. Dictionary keyed by ProductID, lookup 18 ----------
        Console.WriteLine("\n--- Q15. ---");
        Dictionary<int, Product> dict = Products.ToDictionary(p => p.ProductID);
        var p18 = dict[18];
        Console.WriteLine($"{p18.ProductID}: {p18.ProductName} - ${p18.UnitPrice}");

        // ---------- 16. First product with price > $50 ----------
        Console.WriteLine("\n--- Q16. ---");
        var first50 = Products.First(p => p.UnitPrice > 50);
        Console.WriteLine($"{first50.ProductName} - ${first50.UnitPrice}");

        // ---------- 17. FirstOrDefault price > $500 (returns null) ----------
        Console.WriteLine("\n--- Q17. ---");
        var first500 = Products.FirstOrDefault(p => p.UnitPrice > 500);
        Console.WriteLine(first500 == null ? "null (no product found)" : first500.ProductName);

        // ---------- 18. Multiplication table for 7 ----------
        Console.WriteLine("\n--- Q18. ---");
        var table = Enumerable.Range(1, 10).Select(i => $"7 x {i} = {7 * i}");
        foreach (var line in table) Console.WriteLine(line);

        // ---------- 19. Even numbers 1..30 ----------
        Console.WriteLine("\n--- Q19. ---");
        var evens = Enumerable.Range(1, 30).Where(n => n % 2 == 0);
        Console.WriteLine(string.Join(", ", evens));

        // ---------- 20. Concat first 3 product names + first 3 company names ----------
        Console.WriteLine("\n--- Q20. ---");
        var concat = Products.Take(3).Select(p => p.ProductName)
            .Concat(Customers.Take(3).Select(c => c.CompanyName));
        foreach (var s in concat) Console.WriteLine(s);

        // ---------- 21. Zip products with customers ----------
        Console.WriteLine("\n--- Q21. ---");
        var zipped = Products.Zip(Customers,
            (p, c) => $"{p.ProductName} sold to {c.CompanyName}");
        foreach (var s in zipped) Console.WriteLine(s);
    }
}