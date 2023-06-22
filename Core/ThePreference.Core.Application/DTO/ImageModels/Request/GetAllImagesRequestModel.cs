using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Response;

namespace ThePreference.Core.Application.DTO.ImageModels.Request;

public class GetAllImagesRequestModel: IRequest<Result<List<ImageResponseModel>>>
{
    
}