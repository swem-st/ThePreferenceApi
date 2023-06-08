using CSharpFunctionalExtensions;
using MediatR;
using ThePreference.Core.Application.DTO.CategoryModels.Request;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;
using static ThePreference.Domain.Product.Category;

namespace ThePreference.Core.Application.UseCases.Category.Commands;

public class UpdateCategoryCommandUseCase: IRequestHandler<UpdateCategoryRequestModel, Result>
{
    private readonly ICommandCategoryRepository _commandCategoryRepository;
    public UpdateCategoryCommandUseCase(ICommandCategoryRepository commandCategoryRepository)
    {
        _commandCategoryRepository = commandCategoryRepository;
    }

    public async Task<Result> Handle(UpdateCategoryRequestModel request, CancellationToken cancellationToken)
    {
        var category = Update(request.Id, request.Name);

        if (category.IsFailure)
        {
            return Result.Failure(category.Error);
        }

        var result =  await _commandCategoryRepository.UpdateCategory(category.Value);

        return result;
    }
}