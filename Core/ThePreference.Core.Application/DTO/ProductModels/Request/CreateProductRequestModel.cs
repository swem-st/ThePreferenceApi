using MediatR;
using ThePreference.Application.DTO.Wrappers;
namespace ThePreference.Application.DTO.ProductModels.Request;

public class CreateProductRequestModel: IRequest<Response<Guid>>
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    
    public string? Model { get; set; }
    public ICollection<string> Images { get; set; } = null!;
    public ICollection<string> Colors { get; set; } = null!;
}