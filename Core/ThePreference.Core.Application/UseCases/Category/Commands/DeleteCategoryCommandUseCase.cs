using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;

namespace ThePreference.Core.Application.UseCases.Category.Commands;

public class DeleteCategoryCommandUseCase: IRequestHandler<DeleteCategoryRequestModel, Result>
{
    private readonly ICommandCategoryRepository _commandCategoryRepository;
    
    public DeleteCategoryCommandUseCase(ICommandCategoryRepository commandCategoryRepository)
    {
        _commandCategoryRepository = commandCategoryRepository;
    }
    
    public async Task<Result> Handle(DeleteCategoryRequestModel request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            return Result.Failure("Category Id cannot be empty");
        }
        
        var result = await _commandCategoryRepository.DeleteCategory(request.Id);
        return result;
    }
}