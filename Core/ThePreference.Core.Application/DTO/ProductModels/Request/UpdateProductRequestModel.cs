using MediatR;
using ThePreference.Application.DTO.Wrappers;
namespace ThePreference.Application.DTO.ProductModels.Request;

public class UpdateProductRequestModel: IRequest<Response<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public ModelRequestModel Model { get; set; }
    public ICollection<string> Images { get; set; }
    public ICollection<string> Colors { get; set; }
}