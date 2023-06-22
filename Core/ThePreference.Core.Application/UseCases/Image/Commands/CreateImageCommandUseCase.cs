using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;
using static ThePreference.Domain.Product.Image;

namespace ThePreference.Core.Application.UseCases.Image.Commands;

public class CreateImageCommandUseCase : IRequestHandler<CreateImageRequestModel, Result>
{
    private readonly ICommandImageRepository _commandImageRepository;

    public CreateImageCommandUseCase(ICommandImageRepository commandImageRepository)
    {
        _commandImageRepository = commandImageRepository;
    }

    public async Task<Result> Handle(CreateImageRequestModel request, CancellationToken cancellationToken)
    {
        var image = CreateForExistProduct(request.ProductId, request.ImageUrl, request.AltText);

        if (image.IsFailure)
        {
            return Result.Failure(image.Error);
        }

        var result =  await _commandImageRepository.CreateImage(image.Value);

        return result;
    }
}