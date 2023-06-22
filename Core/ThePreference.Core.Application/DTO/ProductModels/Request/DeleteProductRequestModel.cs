using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.ProductModels.Request;

public class DeleteProductRequestModel: IRequest<Result>
{
    public DeleteProductRequestModel(Guid productId)
    {
        Id = productId;
    }
    
    public Guid Id { get; set; }
}