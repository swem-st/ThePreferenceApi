using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.ColorModels.Request;

public class UpdateColorRequestModel: ColorDTO, IRequest<Result>
{
    
}