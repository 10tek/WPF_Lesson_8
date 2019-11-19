using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombinedElementsLesson
{
    public class TraderContext : DbContext
    {
        public TraderContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=A-104-16;Database=TraderDb;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var firstCompany = new Company
            {
                Name = "Alibaba"
            };

            var secondCompany = new Company
            {
                Name = "Google"
            };

            var priceHistory1 = new PriceHistory
            {
                CompanyId = firstCompany.Id,
                Date = DateTime.Now,
                Price = 100
            };
            var priceHistory2 = new PriceHistory
            {
                CompanyId = firstCompany.Id,
                Date = DateTime.Now,
                Price = 200
            };
            var priceHistory3 = new PriceHistory
            {
                CompanyId = firstCompany.Id,
                Date = DateTime.Now,
                Price = 300
            };

            var priceHistory4 = new PriceHistory
            {
                CompanyId = secondCompany.Id,
                Date = DateTime.Now,
                Price = 1000
            };
            var priceHistory5 = new PriceHistory
            {
                CompanyId = secondCompany.Id,
                Date = DateTime.Now,
                Price = 2000
            };
            var priceHistory6 = new PriceHistory
            {
                CompanyId = secondCompany.Id,
                Date = DateTime.Now,
                Price = 3000
            };

            modelBuilder.Entity<Company>().HasData(firstCompany, secondCompany);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory1, priceHistory2, priceHistory3, priceHistory4, priceHistory5, priceHistory6);
        }
    }
}
