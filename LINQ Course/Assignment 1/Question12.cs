using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question12
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 12 ==========");
        string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var result = Arr.OrderBy(l => l.Length)
                        .ThenBy(l => l, StringComparer.OrdinalIgnoreCase);


        foreach (var word in result)
        {
            Console.WriteLine($"  {word,-15} (length: {word.Length})");
        }
    }
}
