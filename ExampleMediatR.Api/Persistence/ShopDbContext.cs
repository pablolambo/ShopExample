using ExampleMediatR.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleMediatR.Api.Persistence
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source={DbPath}");
    }
}
