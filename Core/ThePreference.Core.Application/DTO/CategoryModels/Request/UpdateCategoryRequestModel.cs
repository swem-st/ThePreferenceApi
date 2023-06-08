using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.CategoryModels.Request;

public class UpdateCategoryRequestModel: IRequest<Result>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}