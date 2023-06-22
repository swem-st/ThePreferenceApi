using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Response;

namespace ThePreference.Core.Application.DTO.ProductModels.Request;

public class GetProductsByCategoryRequestModel: IRequest<Result<List<ProductResponseModel>>>
{
   public GetProductsByCategoryRequestModel(Guid categoryId)
   {
      CategoryId = categoryId;
   }
   
   public Guid CategoryId { get; set; } 
}