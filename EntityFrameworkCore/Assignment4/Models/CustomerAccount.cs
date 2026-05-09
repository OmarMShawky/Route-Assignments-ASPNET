using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models;

public class CustomerAccount
{
    public string AccountNumber { get; set; } = null!;
    public int CustomerId { get; set; }
    public DateTime OwnershipStartDate { get; set; }
    public string OwnershipType { get; set; } = null!;
    public string AccountStatus { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public Account Account { get; set; } = null!;
}