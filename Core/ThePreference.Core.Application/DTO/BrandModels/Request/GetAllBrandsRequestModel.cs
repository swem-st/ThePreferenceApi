using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.BrandModels.Response;

namespace ThePreference.Core.Application.DTO.BrandModels.Request;

public class GetAllBrandsRequestModel: IRequest<Result<List<BrandResponseModel>>>
{
    
}