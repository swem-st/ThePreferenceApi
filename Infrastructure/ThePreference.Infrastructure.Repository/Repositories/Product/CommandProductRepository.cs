using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.DataModels.Product;
using ProductDomain = ThePreference.Domain.Product.Product;

namespace ThePreference.Infrastructure.Repository.Repositories.Product;

public class CommandProductRepository : ICommandProductRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    public CommandProductRepository(ProductContext productContext, IMapper mapper)
    {
        _productContext = productContext;
        _mapper = mapper;
    }

    public async Task<Result> CreateProduct(ProductDomain product)
    {
        await using var transaction = await _productContext.Database.BeginTransactionAsync();

        try
        {
            var brand = await _productContext.Brands.FindAsync(product.Brand.Id);
            if (brand == null)
            {
                return Result.Failure<ProductDomain>("Brand not found.");
            }

            var categoryIds = product.Categories.Select(category => category.Id).Distinct().ToList();
            var categories = await _productContext.Categories
                .Where(category => categoryIds.Contains(category.Id))
                .ToListAsync();

            if (categories.Count != categoryIds.Count)
            {
                return Result.Failure<ProductDomain>("One or more categories not found.");
            }

            var colorIds = product.Colors.Select(color => color.Id).Distinct().ToList();
            var colors = await _productContext.Colors
                .Where(color => colorIds.Contains(color.Id))
                .ToListAsync();

            if (colors.Count != colorIds.Count)
            {
                return Result.Failure<ProductDomain>("One or more colors not found.");
            }

            //Our automapper include
            // - Associate the existing Categories with the product entity (ProductCategoryEntity - see last bullet-point in the list)
            // - Associate he existing Colors with the product entity (ProductColorEntity - see last bullet-point in the list)
            // - Create New Images and associate it with the product entity
            // - also we only assign [CategoryId in ProductCategoryEntity] and [ColorId in ProductColorEntity], because:
            //      - The ProductId will be automatically assigned (to ProductCategoryEntity/ProductColorEntity) when the productEntity is saved to the database.
            //      - Also We do not set Category = categoryEntity, or Color = ColorEntity as setting just Id can increase performance. In other cases, maybe we will need to set the whole entity.
            var productEntity = _mapper.Map<ProductEntity>(product);

            // Save the new product entity to the database
            _productContext.Products.Add(productEntity);
            await _productContext.SaveChangesAsync();

            await transaction.CommitAsync();

            return Result.Success(product.Name);
        }
        catch (Exception ex)
        {
            // Handle any exceptions and rollback the transaction if necessary
            await transaction.RollbackAsync();
            return Result.Failure("Failed to create the product. Exception: " + ex.Message);
        }
    }

    public async Task<Result> UpdateProduct(ProductDomain product)
    {
        await using var transaction = await _productContext.Database.BeginTransactionAsync();

        try
        {
            var existingProduct = await _productContext.Products
                .Include(p => p.Model)
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                return Result.Failure<ProductDomain>("Product not found.");
            }

            //Lets check will be we update the brand if ID the same ??? 
            if (existingProduct.BrandId != product.Brand.Id)
            {
                var brand = await _productContext.Brands.FindAsync(product.Brand.Id);
                if (brand == null)
                {
                    return Result.Failure<ProductDomain>("Brand not found.");
                }
            }

            //Lets check will be we update the model if Name the same ??? 
            if (existingProduct.Model != null && existingProduct.Model.Name != product.Model?.Name)
            {
                _productContext.Models.Remove(existingProduct.Model);
            }

            //Lets check will be we update the model if Name the same ??? 
            if (product.IsCategoriesHaveChanged)
            {
                var existingCategories = await _productContext.ProductCategories
                    .Where(item => item.ProductId == product.Id)
                    .ToListAsync();

                if (existingCategories.Any())
                {
                    _productContext.ProductCategories.RemoveRange(existingCategories);
                }

                var categoryIds = product.Categories.Select(category => category.Id).Distinct().ToList();
                var categories = await _productContext.Categories
                    .Where(category => categoryIds.Contains(category.Id))
                    .ToListAsync();

                if (categories.Count != categoryIds.Count)
                {
                    return Result.Failure<ProductDomain>("One or more categories not found.");
                }
            }

            if (product.Images.Any())
            {
                var images = _mapper.Map<List<ImageEntity>>(product.Images);
                images.ForEach(image => image.ProductId = product.Id);
                await _productContext.Images.AddRangeAsync(images);
            }

            if (product.Colors.Any())
            {
                var colorIds = product.Colors.Select(color => color.Id).Distinct().ToList();
                var colors = await _productContext.Colors
                    .Where(color => colorIds.Contains(color.Id))
                    .ToListAsync();

                if (colors.Count != colorIds.Count)
                {
                    return Result.Failure<ProductDomain>("One or more colors not found.");
                }

                var productColors = colors.Select(color => new ProductColorEntity
                {
                    ColorId = color.Id,
                    ProductId = product.Id
                }).ToList();

                await _productContext.ProductColors.AddRangeAsync(productColors);
            }

            if (product.DeletedColors.Any())
            {
                var deletedColors = await _productContext.ProductColors
                    .Where(item => product.DeletedColors.Contains(item.ColorId) && item.ProductId == product.Id)
                    .ToListAsync();

                if (deletedColors.Any())
                {
                    _productContext.ProductColors.RemoveRange(deletedColors);
                }
            }

            //need to check would we remove images if product.Images is empty ???
            //need to check would we remove colors if product.Colors is empty ???
            _mapper.Map(product, existingProduct);
            await _productContext.SaveChangesAsync();

            await transaction.CommitAsync();

            return Result.Success(product.Name);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return Result.Failure<ProductDomain>("Failed to update the product." + ex.Message);
        }
    }

    public async Task<Result> DeleteProduct(Guid productId)
    {
        await using var transaction = await _productContext.Database.BeginTransactionAsync();

        try
        {
            //we using soft delete, so do not delete the product, and relationships with other tables
            var product = await _productContext.Products.FirstOrDefaultAsync(product => product.Id == productId);
            
            if (product == null)
            {
                return Result.Failure<ProductDomain>("Product not found.");
            }

            return Result.Success(product.Name);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return Result.Failure<ProductDomain>("Failed to delete the product." + ex.Message);
        }
    }
}