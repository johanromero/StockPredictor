using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.InMemory;
using SPDAO.Models;

namespace SPDAO
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPrediction> UserPredictions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestingDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<UserPrediction>().HasKey(e => e.Id);
        }
    }

}
