using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;
using static ThePreference.Domain.Product.Image;

namespace ThePreference.Core.Application.UseCases.Image.Commands;

public class UpdateImageCommandUseCase: IRequestHandler<UpdateImageRequestModel, Result>
{
    private readonly ICommandImageRepository _commandImageRepository;

    public UpdateImageCommandUseCase(ICommandImageRepository commandImageRepository)
    {
        _commandImageRepository = commandImageRepository;
    }
    
    public async Task<Result> Handle(UpdateImageRequestModel request, CancellationToken cancellationToken)
    {
        var image = Update(request.Id, request.ImageUrl, request.AltText);

        if (image.IsFailure)
        {
            return Result.Failure(image.Error);
        }

        var result =  await _commandImageRepository.UpdateImage(image.Value);

        return result;
    }
}