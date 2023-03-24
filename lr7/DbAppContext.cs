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
        public DbSet<Phone> Phone { get; set; }

        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Username=postgres;Password=123;Database=Phones_db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasOne(p => p.CompanyEntity)
                                        .WithMany(p => p.PhoneEntites);
        }

    }
}
