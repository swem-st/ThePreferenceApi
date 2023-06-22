using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Response;

namespace ThePreference.Core.Application.DTO.ImageModels.Request;

public class GetImagesByProductRequestModel: IRequest<Result<List<ImageResponseModel>>>
{
   public GetImagesByProductRequestModel(Guid productId)
   {
      ProductId = productId;
   }
   
   public Guid ProductId { get; set; } 
}