using System;
using FitnessTracker.Reporting.Models;
using Microsoft.EntityFrameworkCore;
using Reporting.Models;

namespace Reporting.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers", t => t.ExcludeFromMigrations())
            .HasKey(x => x.Id);
            modelBuilder.Entity<WorkOut>()
            .ToTable("WorkOuts", t => t.ExcludeFromMigrations())
            .HasKey(x => x.Id);

            modelBuilder.Entity<Report>()
            .HasOne(r => r.user)
            .WithMany(u => u.reports)
            .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Stats>()
            .HasOne(s => s.reports)
            .WithOne(r => r.Stats)
            .HasForeignKey<Stats>(s => s.ReportId);
    }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Stats> Stats { get; set; }
}