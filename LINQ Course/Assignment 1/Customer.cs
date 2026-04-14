using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Customer
{
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public override string ToString()
        => $"{CustomerID,-10} | {CompanyName}";
}
