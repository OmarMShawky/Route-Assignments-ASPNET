using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {

        builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(e => e.Description)
               .IsRequired()
               .HasMaxLength(2000);

        builder.Property(e => e.StartDate)
               .IsRequired();

        builder.Property(e => e.EndDate)
               .IsRequired(false);

        builder.Property(e => e.MaxAttendees)
               .IsRequired();

        builder.HasOne(e => e.ParentEvent)
               .WithMany(e => e.Sessions)
               .HasForeignKey(e => e.ParentEventId)
               .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(e => e.Organizer)
               .WithMany(o => o.Events)
               .HasForeignKey(e => e.OrganizerId)
               .OnDelete(DeleteBehavior.Restrict);


        builder.Property<DateTime>("CreatedAt")
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property<DateTime>("ModifiedAt")
               .HasDefaultValueSql("GETUTCDATE()");
    }
}