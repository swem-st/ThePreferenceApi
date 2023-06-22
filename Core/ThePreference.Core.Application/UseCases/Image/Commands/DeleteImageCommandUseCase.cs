using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.ImageModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;

namespace ThePreference.Core.Application.UseCases.Image.Commands;

public class DeleteImageCommandUseCase: IRequestHandler<DeleteImageRequestModel, Result>
{
    private readonly ICommandImageRepository _commandImageRepository;

    public DeleteImageCommandUseCase(ICommandImageRepository commandImageRepository)
    {
        _commandImageRepository = commandImageRepository;
    }
    
    public async Task<Result> Handle(DeleteImageRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure("Image Id cannot be empty");
        }
        
        var result = await _commandImageRepository.DeleteImage(request.Id);
        return result;
    }
}