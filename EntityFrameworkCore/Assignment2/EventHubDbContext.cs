using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EventHub;

public class EventHubDbContext : DbContext
{
    public DbSet<Organizer> Oragnizers => Set<Organizer>();
    public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Attendee> Attendees => Set<Attendee>();
    public DbSet<Badge> Badges => Set<Badge>();
    public DbSet<Registration> Registrations => Set<Registration>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
                "Server=.; Database=EventHub; Trusted_Connection=True; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganizerProfile>(builder =>
        {

            builder.Property(p => p.Biography)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(p => p.WebsiteUrl)
                   .HasMaxLength(300);

            builder.Property(p => p.LogoUrl)
                   .HasMaxLength(300);

            // Organizer and Profile have 1:1 relationship — profile cannot exist without the organizer
            // Cascade: deleting the organizer deletes the profile
            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                   .OnDelete(DeleteBehavior.Cascade);

            // one profile only per organizer
            builder.HasIndex(p => p.OrganizerId).IsUnique();
        });

        // Badge 1:1 optional with Attendee
        modelBuilder.Entity<Badge>(builder =>
        {
            builder.ToTable("Badges");
            builder.HasKey(b => b.Id); // not mandatory
            

            builder.HasAlternateKey(b => b.BadgeNumber);


            builder.Property(b => b.IssuedAt)
                   .HasDefaultValueSql("GETDATE()");


            builder.HasOne(b => b.Attendee)
                   .WithOne(a => a.Badge)
                   .HasForeignKey<Badge>(b => b.AttendeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        });

        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new RegistrationConfiguration());
    }
}