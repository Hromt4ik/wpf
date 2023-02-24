using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class DbAppContext : DbContext
    {
        public DbSet<phone> phone { get; set; }

        public DbSet<company> company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Username=postgres;Password=123;Database=Phones_db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<phone>().HasOne(p => p.CompanyEntity)
                                        .WithMany(p => p.PhoneEntites);
        }

    }
}
