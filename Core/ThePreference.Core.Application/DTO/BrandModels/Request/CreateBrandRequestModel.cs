using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.BrandModels.Request;

public class CreateBrandRequestModel: IRequest<Result>
{
    public string Name { get; set; } = null!;
}