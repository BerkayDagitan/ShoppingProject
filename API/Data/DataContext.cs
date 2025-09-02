using API.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new Product { Id=1, Name = "Iphone 15", Description ="Telefon Açıklaması", Price = 10.0m, IsActive = true, Stock = 100 },
                    new Product { Id=2, Name = "Iphone 16", Description ="Telefon Açıklaması 2", Price = 20.0m, IsActive = true, Stock = 200 },
                    new Product { Id=3, Name = "Iphone 16 Pro", Description ="Telefon Açıklaması 3", Price = 30.0m, IsActive = true, Stock = 300 },
                    new Product { Id=4, Name = "Iphone 16 Pro Max", Description ="Telefon Açıklaması 4", Price = 40.0m, IsActive = true, Stock = 400 }
                }
            );
        }
    }
}