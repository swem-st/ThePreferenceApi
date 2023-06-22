using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Response;

namespace ThePreference.Core.Application.DTO.CategoryModels.Request;

public class GetAllCategoriesRequestModel: IRequest<Result<List<CategoryResponseModel>>>
{

}