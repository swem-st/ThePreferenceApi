using Microsoft.EntityFrameworkCore;
using ThePreference.Infrastructure.Repository.DataModels;
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
    
    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<ProductColorEntity> ProductColors { get; set; }
    public DbSet<BrandEntity> Brands { get; set; }

    public DbSet<ModelEntity> Models { get; set; }
    public DbSet<ImageEntity> Images { get; set; }
    
    private void UpdateTimestamps()
    {
        var entities = ChangeTracker.Entries<BaseEntity>();

        foreach (var entityEntry in entities)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.CreatedAt = DateTime.UtcNow;
                entityEntry.Entity.UpdatedAt = DateTime.UtcNow;
                //entityEntry.Entity.CreatedBy = "YourCreatedByValue"; // Set the actual value here
                //entityEntry.Entity.UpdatedBy = "YourUpdatedByValue"; // Set the actual value here
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.UpdatedAt = DateTime.UtcNow;
                //entityEntry.Entity.UpdatedBy = "YourUpdatedByValue"; // Set the actual value here
            }

            if (entityEntry.State == EntityState.Deleted)
            {
                entityEntry.State = EntityState.Modified;
                entityEntry.Entity.IsDeleted = true;
                entityEntry.Entity.DeletedAt = DateTime.UtcNow;
                //entityEntry.Entity.DeletedBy = "YourDeletedByValue"; // Set the actual value here
            }
        }
    }
}