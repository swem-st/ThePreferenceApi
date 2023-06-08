using Microsoft.EntityFrameworkCore;
using ThePreference.Infrastructure.Repository.DataModels.Product;

namespace ThePreference.Infrastructure.Repository.DataAccess;

public class ProductContext: DbContext
{
    public ProductContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategoryEntity>().HasKey(e => new { e.ProductId, e.CategoryId });
        modelBuilder.Entity<ProductColorEntity>().HasKey(e => new { e.ProductId, e.ColorId });
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<ProductColorEntity> ProductColors { get; set; }
    public DbSet<BrandEntity> Brands { get; set; }

    public DbSet<ModelEntity> Models { get; set; }
    public DbSet<ImageEntity> Images { get; set; }
}