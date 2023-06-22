using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.CategoryModels.Request;

public class UpdateCategoryRequestModel: CategoryDTO, IRequest<Result>
{
}
