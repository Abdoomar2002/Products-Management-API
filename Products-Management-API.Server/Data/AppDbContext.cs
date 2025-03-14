using Microsoft.EntityFrameworkCore;
using Products_Management_API.Server.Models;

namespace Products_Management_API.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.OwnsOne(p => p.Price, price =>
                {
                    price.Property(p => p.Value).HasColumnName("PriceValue");
                    price.Property(p => p.Currency).HasColumnName("PriceCurrency");
                });
            });

        }
    }
}
