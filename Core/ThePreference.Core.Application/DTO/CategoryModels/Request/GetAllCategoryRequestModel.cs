using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Response;

namespace ThePreference.Core.Application.DTO.CategoryModels.Request;

public class GetAllCategoryRequestModel: IRequest<Result<List<CategoryResponseModel>>>
{
   // public GetAllCategoryRequestModel() { }
}