using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GwesReportApi.Models
{
    public class GwesDbContext:DbContext
    {
        public GwesDbContext()
        {
        }

        public GwesDbContext(DbContextOptions<GwesDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasNoKey();
            modelBuilder.Entity<DocModel>().HasNoKey();
            modelBuilder.Entity<AdvAccountProfile>().HasNoKey();
            modelBuilder.Entity<RTAccountProfile>().HasNoKey();

        }

        public DbSet<UserModel> DbUsers { get; set; }
        public DbSet<DocModel> DbDocs { get; set; }
    }
}
