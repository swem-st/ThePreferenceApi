using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels;
using ThePreference.Core.Application.DTO.CategoryModels;
using ThePreference.Core.Application.DTO.ColorModels;
using ThePreference.Core.Application.DTO.ImageModels;

namespace ThePreference.Core.Application.DTO.ProductModels.Request;

public class CreateProductRequestModel: IRequest<Result>
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public BrandDTO Brand { get; set; } = null!;
    public string? Model { get; set; }
    public  ICollection<CategoryDTO>  Categories { get; set; } = null!;
    public ICollection<ImageDTO> Images { get; set; } = null!;
    public ICollection<ColorDTO> Colors { get; set; } = null!;
}