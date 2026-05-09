using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankManagementSystem.Models;

public class Branch
{
    public int Code { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public Manager Manager { get; set; } = null!;
    public int ManagerId { get; set; }
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}