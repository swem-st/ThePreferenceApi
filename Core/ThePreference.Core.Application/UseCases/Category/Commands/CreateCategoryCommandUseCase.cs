using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;
using static ThePreference.Domain.Product.Category;

namespace ThePreference.Core.Application.UseCases.Category.Commands;

public class CreateCategoryCommandUseCase: IRequestHandler<CreateCategoryRequestModel, Result>
{
     private readonly ICommandCategoryRepository _commandCategoryRepository;

    public CreateCategoryCommandUseCase(ICommandCategoryRepository commandCategoryRepository)
    {
        _commandCategoryRepository = commandCategoryRepository;
    }
    
    public async Task<Result> Handle(CreateCategoryRequestModel request, CancellationToken cancellationToken)
    {
        var category = Create(request.Name);

        if (category.IsFailure)
        {
            return Result.Failure(category.Error);
        }
        
        var result  = await _commandCategoryRepository.CreateCategory(category.Value);
        
        return result;
    }
}