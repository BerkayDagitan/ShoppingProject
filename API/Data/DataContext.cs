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
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new Product { Id=1, Name = "Apple Watch Series 1", Description ="Apple Watch Series 1, temel sağlık ve bildirim takibi özelliklerine sahip, spor ve günlük kullanım odaklı bir akıllı saattir.", Price = 7000, IsActive = true, Stock = 100 },
                    new Product { Id=2, Name = "Apple Watch Series 2", Description ="Apple Watch Series 2, daha hızlı bir işlemci ve gelişmiş sağlık izleme özellikleri sunan bir akıllı saattir.", Price = 15000, IsActive = true, Stock = 200 },
                    new Product { Id=3, Name = "Apple Watch Series 3", Description ="Apple Watch Series 3, suya dayanıklılık ve gelişmiş fitness özellikleri ile donatılmış bir akıllı saattir.", Price = 20000, IsActive = true, Stock = 300 },
                    new Product { Id=4, Name = "Xiaomi Redmi Watch 1", Description ="Xiaomi Redmi Watch 1, uygun fiyatlı bir akıllı saat arayanlar için ideal bir seçenektir.", Price = 3500, IsActive = true, Stock = 150 },
                    new Product { Id=5, Name = "Xiaomi Redmi Watch 2", Description ="Xiaomi Redmi Watch 2, daha büyük bir ekran ve geliştirilmiş sağlık izleme özellikleri sunan bir akıllı saattir.", Price = 5000, IsActive = true, Stock = 150 },
                    new Product { Id=6, Name = "Xiaomi Redmi Watch 3", Description ="Xiaomi Redmi Watch 3, daha fazla özellik ve şıklık sunan bir akıllı saattir.", Price = 6000, IsActive = true, Stock = 200 },
                    new Product { Id=7, Name = "Xiaomi Redmi Watch 4", Description ="Xiaomi Redmi Watch 4, daha fazla özelliği uygun fiyatlı bir akıllı saatte arayanlar için ideal bir seçenektir.", Price = 3500, IsActive = true, Stock = 400 }
                }
            );
        }
    }
}