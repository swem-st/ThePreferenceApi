using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;

public interface ICommandCategoryRepository
{
    Task<Result> CreateCategory(Domain.Product.Category request);
    Task<Result> UpdateCategory(Domain.Product.Category request);
    Task<Result> DeleteCategory(Guid categoryId);
}