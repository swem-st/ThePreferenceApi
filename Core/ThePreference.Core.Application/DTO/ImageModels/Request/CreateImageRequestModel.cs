using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.ImageModels.Request;

public class CreateImageRequestModel: IRequest<Result>
{
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; } = null!;
    public string? AltText { get; set; }
}