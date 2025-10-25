using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "app.db");
                optionsBuilder.UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db")}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Subject>().HasData(
            new Subject { SubjectID = 1, SubjectName = "Mathematics", Description = "Math subject", Progress = 50, TargetHours = 40 },
            new Subject { SubjectID = 2, SubjectName = "Programming", Description = "C# Programming", Progress = 30, TargetHours = 60 },
            new Subject { SubjectID = 3, SubjectName = "Physics", Description = "Physics course", Progress = 70, TargetHours = 50 },
            new Subject { SubjectID = 4, SubjectName = "Chemistry", Description = "Chemistry course", Progress = 40, TargetHours = 50 }
            );
        }
    }
}
