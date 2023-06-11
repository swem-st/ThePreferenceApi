using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;
using ThePreference.Infrastructure.Repository.DataAccess;
using CategoryDomain = ThePreference.Domain.Product.Category;

namespace ThePreference.Infrastructure.Repository.Repositories.Category;

public class QueryCategoryRepository: IQueryCategoryRepository
{
    private readonly ProductContext _productContext;
    
    public QueryCategoryRepository(ProductContext productContext)
    {
        _productContext = productContext;
    }
    
    public async Task<Result<CategoryDomain>> GetCategory(Guid id)
    {
        var categoryEntity = await _productContext.Categories.AsNoTracking()
            .Select(category => new CategoryDomain
            {
                Id = category.Id,
                Name = category.Name
            })
            .FirstOrDefaultAsync(category => category.Id == id);

        if (categoryEntity == null)
        {
            return Result.Failure<CategoryDomain>($"{nameof(Category)} with Id: '{id}' is not exist.");
        }

        return Result.Success(categoryEntity);
    }

    public async Task<Result<List<CategoryDomain>>> GetAllCategories()
    {
        var categoryEntities = await _productContext.Categories.AsNoTracking()
            .Select(category => new CategoryDomain
            {
                Id = category.Id,
                Name = category.Name
            })
            .ToListAsync();

        return Result.Success(categoryEntities);
    }
}