using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class ColorEntity: BaseEntity
{
    [Required]
    public bool IsBasic { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = null!;
    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    public ICollection<ProductColorEntity> ProductColorEntities { get; set; } = null!;
}