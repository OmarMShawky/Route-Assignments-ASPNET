using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LinqAssignment1;

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int UnitsInStock { get; set; }

    public override string ToString()
        => $"{Name}\t| {Category}\t| {Price} EGP\t| Stock: {UnitsInStock}";
}
