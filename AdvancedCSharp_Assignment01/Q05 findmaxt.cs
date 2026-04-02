using System;
using System.Collections.Generic;
using System.Text;

namespace Generics;

public static class MaxFinder
{
    public static T FindMax<T>(IEnumerable<T> source)
    where T : IComparable<T>
    {
        T max = default!;
        bool first = true;
        foreach (var item in source)
        {
            if (first || item.CompareTo(max) > 0)
            {
                max = item;
                first = false;
            }
        }
        return max;
    }
}
