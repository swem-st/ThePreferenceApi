using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class ColorEntity
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public ICollection<ProductColorEntity> ProductColorEntities { get; set; } = null!;
}