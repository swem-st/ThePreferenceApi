using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;


public class ImageEntity
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string ImageUrl { get; set; } = null!;

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}