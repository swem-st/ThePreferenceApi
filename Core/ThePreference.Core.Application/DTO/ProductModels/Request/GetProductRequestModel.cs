using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Response;

namespace ThePreference.Core.Application.DTO.ProductModels.Request;

public class GetProductRequestModel: IRequest<Result<ProductResponseModel>>
{
    public GetProductRequestModel(Guid productId)
    {
        Id = productId;
    }
    
    public Guid Id { get; set; }
}