using System;
using System.Collections.Generic;

public class Exercise4
{
    public static void UniqueEmailValidator()
    {
        var emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        emails.Add("Ahmed@test.com");
        emails.Add("Omar@test.com");
        emails.Add("Mona@test.com");
        emails.Add("Sara@Test.Com");

        Console.WriteLine("Unique emails count: " + emails.Count);

        Console.WriteLine("Stored emails:");
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }

        var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
        var setB = new HashSet<int> { 4, 5, 6, 7, 8 };

        var union = new HashSet<int>(setA);
        union.UnionWith(setB);
        Console.WriteLine("\nUnion:");
        PrintSet(union);

        var intersection = new HashSet<int>(setA);
        intersection.IntersectWith(setB);
        Console.WriteLine("Intersection:");
        PrintSet(intersection);

        var difference = new HashSet<int>(setA);
        difference.ExceptWith(setB);
        Console.WriteLine("A - B:");
        PrintSet(difference);

        var smallSet = new HashSet<int> { 1, 2 };
        bool isSubset = smallSet.IsSubsetOf(setA);
        Console.WriteLine("\nIs {1,2} subset of A? " + isSubset);
    }

    static void PrintSet(HashSet<int> set)
    {
        foreach (var item in set)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}