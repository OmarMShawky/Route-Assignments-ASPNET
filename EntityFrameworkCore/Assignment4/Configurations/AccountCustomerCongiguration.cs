using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Configurations;

public class AccountCustomerCongiguration : IEntityTypeConfiguration<CustomerAccount>
{
    public void Configure(EntityTypeBuilder<CustomerAccount> builder)
    {
        builder.HasKey(ca => new { ca.AccountNumber, ca.CustomerId }); // Composite PK

        builder.HasOne(ca => ca.Account)
               .WithMany(a => a.CustomerAccounts)
               .HasForeignKey(ca => ca.AccountNumber)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ac => ac.Customer)
               .WithMany(c => c.CustomerAccounts)
               .HasForeignKey(ac => ac.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);


    }
}