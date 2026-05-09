using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models;

public class Transaction
{
    public string Number { get; set; } = null!;
    public DateTime TranDate { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = null!;
    public string? Note { get; set; }
    public Account Account { get; set; } = null!;
    public string AccountNumber { get; set; } = null!;
}