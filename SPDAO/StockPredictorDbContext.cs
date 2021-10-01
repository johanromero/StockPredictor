
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using SPDomain;
using SPDomain.Persistent;
using Microsoft.Extensions.Configuration;

namespace StockPredictor.Data
{
    public class StockPredictorDbContext : DbContext
    {
        public StockPredictorDbContext(IConfiguration config)
        {
            Configuration = config;
        }

        public static IConfiguration Configuration { get; set; }
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
