using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Number);

        builder.HasOne(t => t.Account)
               .WithMany(a => a.Transactions)
               .HasForeignKey(t => t.AccountNumber)
               .OnDelete(DeleteBehavior.Restrict);
    }
}