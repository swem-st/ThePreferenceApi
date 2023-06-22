using System.ComponentModel.DataAnnotations;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;


public class ImageEntity
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(2048)]
    public string ImageUrl { get; set; } = null!;
    
    [MaxLength(500)]
    public string? AltText { get; set; }

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}