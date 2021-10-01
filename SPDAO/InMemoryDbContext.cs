using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.InMemory;
using SPDomain.Persistent;

namespace SPDao
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestingDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Prediction>().HasKey(e => e.Id);
        }
    }

}
