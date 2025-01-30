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

            modelBuilder.Entity<WorkoutExercise>(we => 
            we.HasKey(we => new { we.ExerciseId, we.WorkoutId }
            ));

            modelBuilder.Entity<User>()
            .HasMany(b => b.workOut)
            .WithOne(x=> x.user)
            .HasForeignKey(y => y.UserId);

            modelBuilder.Entity<WorkOut>()
            .HasMany(b => b.Comments)
            .WithOne(x => x.workOut)
            .HasForeignKey(y => y.WorkoutId);

            modelBuilder.Entity<User>()
            .HasMany(b => b.Comments)
            .WithOne(x=> x.User)
            .HasForeignKey(y => y.UserId);
            
            modelBuilder.Entity<WorkoutExercise>()
            .HasOne(ts => ts.Exercise)
            .WithMany(tr => tr.WorkoutExercises)
            .HasForeignKey(ts => ts.ExerciseId);

            modelBuilder.Entity<WorkoutExercise>()
            .HasOne(ts => ts.Workout)
            .WithMany(tr => tr.WorkoutExercises)
            .HasForeignKey(ts => ts.WorkoutId);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkOut> WorkOuts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    }
}