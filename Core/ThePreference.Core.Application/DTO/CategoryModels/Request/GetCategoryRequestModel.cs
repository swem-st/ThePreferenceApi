using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Response;

namespace ThePreference.Core.Application.DTO.CategoryModels.Request;

public class GetCategoryRequestModel: IRequest<Result<CategoryResponseModel>>
{
    public GetCategoryRequestModel(Guid categoryId)
    {
        Id = categoryId;
    }
    
    public Guid Id { get; set; }
}