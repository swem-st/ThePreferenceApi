using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.ImageModels.Request;

public class UpdateImageRequestModel: ImageDTO, IRequest<Result>
{
    
}