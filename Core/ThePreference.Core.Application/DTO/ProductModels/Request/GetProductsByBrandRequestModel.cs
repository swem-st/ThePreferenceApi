using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Response;

namespace ThePreference.Core.Application.DTO.ProductModels.Request;

public class GetProductsByBrandRequestModel: IRequest<Result<List<ProductResponseModel>>>
{
   public GetProductsByBrandRequestModel(Guid brandId)
   {
      BrandId = brandId;
   }
   
   public Guid BrandId { get; set; } 
}