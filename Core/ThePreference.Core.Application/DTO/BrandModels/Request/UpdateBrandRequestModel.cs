using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.BrandModels.Request;

public class UpdateBrandRequestModel: IRequest<Result>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}