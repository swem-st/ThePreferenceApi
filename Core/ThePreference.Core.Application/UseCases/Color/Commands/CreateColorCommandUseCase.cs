using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ColorModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;
using static ThePreference.Domain.Product.Color;

namespace ThePreference.Core.Application.UseCases.Color.Commands;

public class CreateColorCommandUseCase : IRequestHandler<CreateColorRequestModel, Result>
{
    private readonly ICommandColorRepository _commandColorRepository;

    public CreateColorCommandUseCase(ICommandColorRepository commandColorRepository)
    {
        _commandColorRepository = commandColorRepository;
    }

    public async Task<Result> Handle(CreateColorRequestModel request, CancellationToken cancellationToken)
    {
        var color = Create(request.IsBasic, request.Name, request.Code);

        if (color.IsFailure)
        {
            return Result.Failure(color.Error);
        }

        var result =  await _commandColorRepository.CreateColor(color.Value);

        return result;
    }
}