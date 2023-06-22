using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ColorModels.Response;

namespace ThePreference.Core.Application.DTO.ColorModels.Request;

public class GetColorRequestModel: IRequest<Result<ColorResponseModel>>
{
    public GetColorRequestModel(Guid colorId)
    {
        Id = colorId;
    }
    
    public Guid Id { get; set; }
}