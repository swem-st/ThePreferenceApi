using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Response;

namespace ThePreference.Core.Application.DTO.ImageModels.Request;

public class GetImageRequestModel: IRequest<Result<ImageResponseModel>>
{
    public GetImageRequestModel(Guid imageId)
    {
        Id = imageId;
    }
    
    public Guid Id { get; set; }
}