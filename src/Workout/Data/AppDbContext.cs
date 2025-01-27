using Microsoft.EntityFrameworkCore;
using Workout.Models;

namespace Workout.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers", t => t.ExcludeFromMigrations())
            .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
            .HasMany(b => b.workOut)
            .WithOne(x=> x.user)
            .HasForeignKey(y => y.UserId);

            modelBuilder.Entity<WorkOut>()
            .HasMany(b => b.Comments)
            .WithOne(x => x.workOut)
            .HasForeignKey(y => y.WorkoutId);
            
            modelBuilder.Entity<WorkOut>()
            .HasMany(b => b.Exercises)
            .WithOne(x=> x.workOut)
            .HasForeignKey(y => y.WorkoutId);

            modelBuilder.Entity<User>()
            .HasMany(b => b.Comments)
            .WithOne(x=> x.User)
            .HasForeignKey(y => y.UserId);
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkOut> WorkOuts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}