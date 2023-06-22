using ThePreference.Core.Application.DTO.BrandModels;
using ThePreference.Core.Application.DTO.CategoryModels;
using ThePreference.Core.Application.DTO.ColorModels;
using ThePreference.Core.Application.DTO.ImageModels;

namespace ThePreference.Core.Application.DTO.ProductModels.Response;

public class ProductResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }  = null!;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public  ICollection<CategoryDTO>  Category { get; set; } = null!;
    public BrandDTO Brand { get; set; } = null!;
    public string? Model { get; set; }
    public ICollection<ImageDTO> Images { get; set; }  = null!;
    public ICollection<ColorDTO> Colors { get; set; }  = null!;
}