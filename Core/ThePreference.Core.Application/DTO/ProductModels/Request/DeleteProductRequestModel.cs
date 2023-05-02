using MediatR;
using ThePreference.Application.DTO.Wrappers;
namespace ThePreference.Application.DTO.ProductModels.Request;

public class DeleteProductRequestModel: IRequest<Response<Guid>>
{
    public DeleteProductRequestModel(Guid productId)
    {
        ProductId = productId;
    }
    
    public Guid ProductId { get; }
}