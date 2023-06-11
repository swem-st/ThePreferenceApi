using MediatR;
using ThePreference.Application.DTO.ProductModels.Response;
using ThePreference.Application.DTO.Wrappers;
using ThePreference.Core.Application.DTO.Wrappers;

namespace ThePreference.Application.DTO.ProductModels.Request;

public class GetProductsByCategoryRequestModel: IRequest<PagedResponse<ProductResponseModel>>
{
   public GetProductsByCategoryRequestModel(Guid categoryId)
   {
      CategoryId = categoryId;
   }
   
   public Guid CategoryId { get; } 
}