using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankManagementSystem.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(b => b.Code);

        builder.HasAlternateKey(b => b.ManagerId);

        builder.HasOne(b => b.Manager)
               .WithOne(m => m.Branch)
               .HasForeignKey<Branch>(b => b.ManagerId);
    }
}