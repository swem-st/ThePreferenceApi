using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ColorModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;

namespace ThePreference.Core.Application.UseCases.Color.Commands;

public class DeleteColorCommandUseCase: IRequestHandler<DeleteColorRequestModel, Result>
{
    private readonly ICommandColorRepository _commandColorRepository;

    public DeleteColorCommandUseCase(ICommandColorRepository commandColorRepository)
    {
        _commandColorRepository = commandColorRepository;
    }
    
    public async Task<Result> Handle(DeleteColorRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure("Color Id cannot be empty");
        }
        
        var result = await _commandColorRepository.DeleteColor(request.Id);
        return result;
    }
}