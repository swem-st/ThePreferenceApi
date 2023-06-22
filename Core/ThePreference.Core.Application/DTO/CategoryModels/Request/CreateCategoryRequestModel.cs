using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.CategoryModels.Request;

public class CreateCategoryRequestModel: IRequest<Result>
{
    public string Name { get; set; } = null!;
    
}