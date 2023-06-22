using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class BrandEntity: BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = null!;
}