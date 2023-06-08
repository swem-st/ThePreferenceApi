using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class ModelEntity
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}