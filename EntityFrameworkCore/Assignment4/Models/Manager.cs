using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Models;

public class Manager
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateOnly HireDate { get; set; }
    public Branch Branch { get; set; } = null!;
}