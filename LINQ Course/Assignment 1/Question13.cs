using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Question13
{
    public static void Answer()
    {
        Console.WriteLine("========== Question 13 ==========");

        string[] digits = { "zero", "one", "two", "three", "four",
                                "five", "six", "seven", "eight", "nine" };

        var result = digits.Where(d => d[1] == 'i')
                           .Reverse();


        result.Print();

    }
}
