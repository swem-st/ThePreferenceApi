using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThePreference.Infrastructure.Repository.DataModels.Product;

public class ProductEntity: BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    [MaxLength(500)]
    public string? Title { get; set; }
    
    [MaxLength(2000)]
    public string? Description { get; set; }
    
    [Precision(14, 2)]
    public decimal Price { get; set; }
    
    public Guid BrandId { get; set; }
    public BrandEntity Brand{ get; set; } = null!;
    
    public ModelEntity? Model{ get; set; }
    
    //Many to many relationship
    public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = null!;
    
    public ICollection<ImageEntity> Images { get; set; } = null!;

    //Many to many relationship
    public ICollection<ProductColorEntity> ProductsColors { get; set; } = null!;
}