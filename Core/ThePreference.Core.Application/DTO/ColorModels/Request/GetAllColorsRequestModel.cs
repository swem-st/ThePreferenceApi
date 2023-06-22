using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ColorModels.Response;

namespace ThePreference.Core.Application.DTO.ColorModels.Request;

public class GetAllColorsRequestModel: IRequest<Result<List<ColorResponseModel>>>
{
    
}