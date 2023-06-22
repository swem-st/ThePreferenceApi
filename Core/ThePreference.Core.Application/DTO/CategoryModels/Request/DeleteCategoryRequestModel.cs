using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.CategoryModels.Request;

public class DeleteCategoryRequestModel: IRequest<Result>
{
    public DeleteCategoryRequestModel(Guid categoryId)
    {
        Id = categoryId;
    }
    
    public Guid Id { get; set; }
}