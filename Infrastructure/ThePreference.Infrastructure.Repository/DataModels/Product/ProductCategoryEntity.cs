namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class ProductCategoryEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}