using BankManagementSystem;
using BankManagementSystem.Models;
using BankManagementSystem.Configurations;
using Microsoft.EntityFrameworkCore;

using var dbContext = new BankManagementSystemDbContext();

// Seed initial data
SeedData(dbContext);

// Main menu
bool running = true;
while (running)
{
    Console.WriteLine("Bank Management System");
    Console.WriteLine("1. Add a new Customer");
    Console.WriteLine("2. Open a new Account for a Customer");
    Console.WriteLine("3. Update Account Status");
    Console.WriteLine("4. Remove an Account from a Customer");
    Console.WriteLine("5. List all Customers (with accounts)");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Enter your choice: ");

    string? raw = Console.ReadLine();

    if (!int.TryParse(raw, out int choice))
    {
        Console.WriteLine("Invalid input — please enter a number between 0 and 5.");
        continue;
    }

    switch (choice)
    {
        case 1: AddCustomer(dbContext); break;
        case 2: OpenAccount(dbContext); break;
        case 3: UpdateAccountStatus(dbContext); break;
        case 4: RemoveAccountFromCustomer(dbContext); break;
        case 5: ListCustomers(dbContext); break;
        case 0:
            Console.WriteLine("Exit");
            running = false;
            break;
        default:
            Console.WriteLine(" Wrong option. Please choose a number from 0 to 5.");
            
            break;
    }
}
static void SeedData(BankManagementSystemDbContext db)
{
    if (db.Managers.Any() && db.Branchs.Any()) return;

    Console.WriteLine("Seeding initial data");

    if (!db.Managers.Any())
    {
        var managers = new List<Manager>
        {
            new Manager
            {
                Name = "Omar Shawky",
                Email = "omar.shawky@nationalbank.com",
                PhoneNumber = "01012345678",
                HireDate = new DateOnly(2020, 3, 10)
            },
            new Manager
            {
                Name = "Mohamed Ahmed",
                Email = "mohamed.ahmed@nationalbank.com",
                PhoneNumber = "01234567890",
                HireDate = new DateOnly(2018, 7, 22)
            },
            new Manager
            {
                Name = "Khaled Ali",
                Email = "khaled.ali@nationalbank.com",
                PhoneNumber = "01234567890",
                HireDate = new DateOnly(2012, 1, 5)
            }
        };

        db.Managers.AddRange(managers);
        db.SaveChanges();
        Console.WriteLine("Managers seeded");
    }

    // --- Branches ---
    if (!db.Branchs.Any())
    {
        var mgrs = db.Managers.OrderBy(m => m.Id).ToList();

        var branches = new List<Branch>
        {
            new Branch
            {
                Name        = "Cairo Main Branch",
                Address     = "12 Tahrir Square, Cairo",
                PhoneNumber = "0223456789",
                ManagerId   = mgrs[0].Id
            },
            new Branch
            {
                Name        = "Alexandria Branch",
                Address     = "5 Corniche Road, Alexandria",
                PhoneNumber = "0312345678",
                ManagerId   = mgrs[1].Id
            },
            new Branch
            {
                Name        = "Giza Branch",
                Address     = "88 Haram Street, Giza",
                PhoneNumber = "0387654321",
                ManagerId   = mgrs[2].Id
            }
        };

        db.Branchs.AddRange(branches);
        db.SaveChanges();
    }
}

static string ReadNonEmpty(string prompt)
{
    string? value;
    do
    {
        Console.Write(prompt);
        value = Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(value))
            Console.WriteLine("This field cannot be empty — please try again.");
    }
    while (string.IsNullOrEmpty(value));
    return value;
}

static int ReadInt(string prompt)
{
    int value;
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out value))
            return value;
        Console.WriteLine("Expected a whole number — please try again.");
    }
}

static decimal ReadDecimal(string prompt)
{
    decimal value;
    while (true)
    {
        Console.Write(prompt);
        if (decimal.TryParse(Console.ReadLine(), out value) && value >= 0)
            return value;
        Console.WriteLine("Expected a non-negative number — please try again.");
    }
}

static string ReadChoice(string prompt, params string[] allowed)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();
        foreach (var opt in allowed)
            if (string.Equals(input, opt, StringComparison.OrdinalIgnoreCase))
                return opt;
        Console.WriteLine($"Please enter one of: {string.Join(" / ", allowed)}");
    }
}

//  Menu Option 1 — Add a new Customer

static void AddCustomer(BankManagementSystemDbContext db)
{
    Console.WriteLine("Add a New Customer");

    string fullName = ReadNonEmpty("  Full Name      : ");
    string nationalId = ReadNonEmpty("  National ID    : ");

    DateOnly dob;
    while (true)
    {
        Console.Write("Date of Birth Year-Month-Day");
        if (DateOnly.TryParse(Console.ReadLine(), out dob)) break;
        Console.WriteLine("Invalid date — use the format YYYY-MM-DD.");
    }

    string email = ReadNonEmpty("  Email          : ");
    string phone = ReadNonEmpty("  Phone          : ");
    string address = ReadNonEmpty("  Address        : ");
    string type = ReadChoice("  Customer Type  (Individual / Business): ",
                                  "Individual", "Business");

    var customer = new Customer
    {
        FullName = fullName,
        NationalId = nationalId,
        DateOfBirth = dob,
        Email = email,
        Phone = phone,
        Address = address,
        Type = type
    };

    db.Customers.Add(customer);
    db.SaveChanges();

}

//  Menu Option 2 — Open a new Account for a Customer

static void OpenAccount(BankManagementSystemDbContext db)
{
    Console.WriteLine("Open a New Account for a Customer");

    // Account number — must be unique
    string accountNumber;
    while (true)
    {
        accountNumber = ReadNonEmpty("  Account Number : ");
        if (!db.Accounts.Any(a => a.Number == accountNumber)) break;
        Console.WriteLine($"  ✗ Account number '{accountNumber}' already exists — try a different number.");
    }

    string accountType = ReadChoice("  Account Type   (Savings / Current / Fixed): ",
                                    "Savings", "Current", "Fixed");

    // Branch — must exist
    int branchCode;
    Branch? branch;
    while (true)
    {
        branchCode = ReadInt("  Branch Code    : ");
        branch = db.Branchs.Find(branchCode);
        if (branch != null) break;
        Console.WriteLine($"No branch found with code {branchCode}.");
    }

    // Customer — must exist
    int customerId;
    Customer? customer;
    while (true)
    {
        customerId = ReadInt("  Customer ID    : ");
        customer = db.Customers.Find(customerId);
        if (customer != null) break;
        Console.WriteLine($"  ✗ No customer found with ID {customerId}.");
    }

    string ownershipRole = ReadChoice("  Ownership Role (Primary / CoHolder): ",
                                      "Primary", "CoHolder");

    decimal initialBalance = ReadDecimal("  Initial Balance: ");

    var account = new Account
    {
        Number = accountNumber,
        Type = accountType,
        CurrentBalance = initialBalance,
        OpeningDate = DateTime.Now,
        BranchCode = branchCode
    };

    var customerAccount = new CustomerAccount
    {
        AccountNumber = accountNumber,
        CustomerId = customerId,
        OwnershipStartDate = DateTime.Now,
        OwnershipType = ownershipRole,
        AccountStatus = "Active"
    };

    db.Accounts.Add(account);
    db.CustomerAccounts.Add(customerAccount);
    db.SaveChanges();
}

//  Menu Option 3 — Update Account Status

static void UpdateAccountStatus(BankManagementSystemDbContext db)
{
    Console.WriteLine("Update Account Status");

    string accountNumber = ReadNonEmpty("Account Number : ");
    int customerId = ReadInt("Customer ID : ");

    var ca = db.CustomerAccounts
               .FirstOrDefault(x => x.AccountNumber == accountNumber
                                 && x.CustomerId == customerId);

    if (ca == null)
    {
        Console.WriteLine("This CustomerAccount Doesn't Exist");
        return;
    }

    string oldStatus = ca.AccountStatus;
    ca.AccountStatus = oldStatus == "Active" ? "Inactive" : "Active";
    db.SaveChanges();

    Console.WriteLine($"\n  ✓ Status updated:  {oldStatus}  →  {ca.AccountStatus}");
}

//  Menu Option 4 — Remove an Account from a Customer

static void RemoveAccountFromCustomer(BankManagementSystemDbContext db)
{
    Console.WriteLine("Remove an Account from a Customer");

    string accountNumber = ReadNonEmpty(" Account Number : ");
    int customerId = ReadInt("Customer ID : ");

    var ca = db.CustomerAccounts
               .FirstOrDefault(x => x.AccountNumber == accountNumber
                                 && x.CustomerId == customerId);

    if (ca == null)
    {
        Console.WriteLine("This CustomerAccount Doesn't Exist");
        return;
    }

    db.CustomerAccounts.Remove(ca);
    db.SaveChanges();

}

//  Menu Option 5 — List all Customers (with accounts)

static void ListCustomers(BankManagementSystemDbContext db)
{
    Console.WriteLine("All Customers :");

    var customers = db.Customers.Include(c => c.CustomerAccounts)
                                                .ThenInclude(ca => ca.Account)
                                             .OrderBy(c => c.Id)
                                             .ToList();

    if (!customers.Any())
    {
        Console.WriteLine("  No customers found in the database.");
        return;
    }

    foreach (var c in customers)
    {
        Console.WriteLine($" Customer ID : {c.Id}");
        Console.WriteLine($" Name : {c.FullName}");
        Console.WriteLine($" National ID : {c.NationalId}");
        Console.WriteLine($" Type : {c.Type}");
        Console.WriteLine($" Date of Birth : {c.DateOfBirth}");
        Console.WriteLine($" Email : {c.Email}");
        Console.WriteLine($" Phone : {c.Phone}");
        Console.WriteLine($" Address : {c.Address}");

        if (c.CustomerAccounts.Any())
        {
            Console.WriteLine($" Accounts :");
            foreach (var ca in c.CustomerAccounts)
            {
                var acc = ca.Account;
                Console.WriteLine($" Number    : {acc.Number}");
                Console.WriteLine($" Type      : {acc.Type}");
                Console.WriteLine($" Balance   : {acc.CurrentBalance:C}");
                Console.WriteLine($" Opened    : {acc.OpeningDate:yyyy-MM-dd}");
                Console.WriteLine($" Role      : {ca.OwnershipType}");
                Console.WriteLine($" Status    : {ca.AccountStatus}");
            }
        }
        else
        {
            Console.WriteLine($"No Accounts Found");
        }
        
    }
}