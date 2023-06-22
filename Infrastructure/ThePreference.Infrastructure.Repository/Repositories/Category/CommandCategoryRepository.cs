using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Category;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.DataModels.Product;
using CategoryDomain = ThePreference.Domain.Product.Category;

namespace ThePreference.Infrastructure.Repository.Repositories.Category;

public class CommandCategoryRepository : ICommandCategoryRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    public CommandCategoryRepository(ProductContext productContext, IMapper mapper)
    {
        _productContext = productContext;
        _mapper = mapper;
    }

    public async Task<Result> CreateCategory(CategoryDomain request)
    {
        var existingCategory = await _productContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(category => category.Name == request.Name);

        if (existingCategory != null)
        {
            if (existingCategory.IsDeleted)
            {
                existingCategory.IsDeleted = false;
                _productContext.Categories.Update(existingCategory);
                await _productContext.SaveChangesAsync();
                return Result.Success(request.Name);
            }

            return Result.Failure<String>($"{nameof(Category)} with name: '{request.Name}' already exist.");
        }

        var categoryEntity = _mapper.Map<CategoryEntity>(request);
        await _productContext.Categories.AddAsync(categoryEntity);
        
        await _productContext.SaveChangesAsync();
        return Result.Success(request.Name);
    }

    public async Task<Result> UpdateCategory(CategoryDomain request)
    {
        var existingCategory = await _productContext.Categories
            .FirstOrDefaultAsync(category => category.Id == request.Id && !category.IsDeleted);

        if (existingCategory == null)
        {
            return Result.Failure($"{nameof(Category)} with Id: '{request.Id}' does not exist.");
        }

        var categoryWithSameName = await _productContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(category => category.Name == request.Name && category.Id != request.Id);

        if (categoryWithSameName != null)
        {
            var error = categoryWithSameName.IsDeleted
                ? "have been removed, please restore it first"
                : "already exist!";

            return Result.Failure($"{nameof(Category)} with name: '{request.Name}' {error}.");
        }

        _mapper.Map(request, existingCategory);

        _productContext.Categories.Update(existingCategory);
        await _productContext.SaveChangesAsync();
        return Result.Success(request.Name);
    }

    public async Task<Result> DeleteCategory(Guid categoryId)
    {
        var existingCategory =
            await _productContext.Categories.FirstOrDefaultAsync(category =>
                category.Id == categoryId && !category.IsDeleted);
        if (existingCategory == null)
        {
            return Result.Failure($"{nameof(Category)} with Id: '{categoryId}' does not exist.");
        }

        _productContext.Categories.Remove(existingCategory);
        await _productContext.SaveChangesAsync();
        return Result.Success(existingCategory.Name);
    }
}