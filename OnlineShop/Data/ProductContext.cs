using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{

    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(entity=> entity.ProductId);
                entity.Property(entity => entity.ProductName);
                entity.Property(entity => entity.ProductDescription);
                entity.Property(entity => entity.ProductPrice);
            }) ;

        }
    }
}
