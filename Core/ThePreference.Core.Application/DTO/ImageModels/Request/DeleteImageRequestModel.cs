using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.ImageModels.Request;

public class DeleteImageRequestModel: IRequest<Result>
{
    public DeleteImageRequestModel(Guid imageId)
    {
        Id = imageId;
    }
    
    public Guid Id { get; set; }
}