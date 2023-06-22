using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ProductModels.Response;

namespace ThePreference.Core.Application.DTO.ProductModels.Request;

public class GetAllProductsRequestModel: IRequest<Result<List<ProductResponseModel>>>
{

}