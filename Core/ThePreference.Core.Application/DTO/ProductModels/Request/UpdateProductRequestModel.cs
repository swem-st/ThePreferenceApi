using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels;
using ThePreference.Core.Application.DTO.CategoryModels;
using ThePreference.Core.Application.DTO.ColorModels;
using ThePreference.Core.Application.DTO.ImageModels;
using ThePreference.Domain.Product;

namespace ThePreference.Core.Application.DTO.ProductModels.Request;

public class UpdateProductRequestModel : IRequest<Result>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public BrandDTO Brand { get; set; } = null!;
    public string? Model { get; set; }
    public ICollection<CategoryDTO> Categories { get; set; } = null!;
    public bool  IsCategoriesHaveChanged { get; set; }
    public ICollection<ImageDTO>? NewImages { get; set; } 
    public ICollection<ColorDTO>? NewColors { get; set; }
    public ICollection<Guid>? DeletedColors { get; set; }
}