using CSharpFunctionalExtensions;
using MediatR;

namespace ThePreference.Core.Application.DTO.ColorModels.Request;

public class DeleteColorRequestModel: IRequest<Result>
{
    public DeleteColorRequestModel(Guid colorId)
    {
        Id = colorId;
    }
    
    public Guid Id { get; set; }
}