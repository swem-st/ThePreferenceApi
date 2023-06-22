using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.ColorModels.Request;

public class CreateColorRequestModel: IRequest<Result>
{
    public bool IsBasic { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
}