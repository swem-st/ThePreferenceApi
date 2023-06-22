using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ColorModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;
using static ThePreference.Domain.Product.Color;

namespace ThePreference.Core.Application.UseCases.Color.Commands;

public class UpdateColorCommandUseCase: IRequestHandler<UpdateColorRequestModel, Result>
{
    private readonly ICommandColorRepository _commandColorRepository;

    public UpdateColorCommandUseCase(ICommandColorRepository commandColorRepository)
    {
        _commandColorRepository = commandColorRepository;
    }
    
    public async Task<Result> Handle(UpdateColorRequestModel request, CancellationToken cancellationToken)
    {
        var color = Update(request.Id, request.IsBasic, request.Name, request.Code);

        if (color.IsFailure)
        {
            return Result.Failure(color.Error);
        }

        var result =  await _commandColorRepository.UpdateColor(color.Value);

        return result;
    }
}