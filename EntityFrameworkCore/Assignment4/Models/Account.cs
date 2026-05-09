using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankManagementSystem.Models;

public class Account
{
    [Key]
    public string Number { get; set; } = null!;
    public decimal CurrentBalance { get; set; }
    public string Type { get; set; } = null!;
    public DateTime OpeningDate { get; set; }
    public int BranchCode { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();
    public Branch Branch { get; set; } = null!;
}