using MediatR;
using ThePreference.Application.DTO.ProductModels.Response;
using ThePreference.Application.DTO.Wrappers;

namespace ThePreference.Application.DTO.ProductModels.Request;

public class GetProductRequestModel: IRequest<Response<ProductResponseModel>>
{
    public GetProductRequestModel(Guid productId)
    {
        ProductId = productId;
    }
    
    public Guid ProductId { get; }
}