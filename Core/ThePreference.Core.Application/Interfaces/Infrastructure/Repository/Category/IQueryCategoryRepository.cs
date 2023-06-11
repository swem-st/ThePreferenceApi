using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;

public interface IQueryCategoryRepository
{
    Task<Result<Domain.Product.Category>> GetCategory(Guid id);
    Task<Result<List<Domain.Product.Category>>> GetAllCategories();

}