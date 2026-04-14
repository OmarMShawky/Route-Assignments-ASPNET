using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment1;

public class Order
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }

    public override string ToString()
        => $"Order #{OrderID} | {OrderDate:dd-MM-yyyy} | {Total} EGP";
}
