using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class CategoryEntity: BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = null!;
}