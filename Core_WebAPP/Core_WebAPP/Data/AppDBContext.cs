using Core_WebAPP.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebAPP.Data
{
    public class AppDBContext : DbContext
    {
        private readonly IConfiguration _Config;
        public DbSet<Contact> Contact { get; set; }

        public AppDBContext(IConfiguration config)
        {
            _Config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_Config["ConnectionStrings:CTS_CoreConn"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
