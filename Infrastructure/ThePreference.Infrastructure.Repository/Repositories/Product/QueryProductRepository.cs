using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;
using ThePreference.Infrastructure.Repository.DataAccess;
using ProductDomain = ThePreference.Domain.Product.Product;
using CategoryDomain = ThePreference.Domain.Product.Category;
using BrandDomain = ThePreference.Domain.Product.Brand;
using ImageDomain = ThePreference.Domain.Product.Image;
using ColorDomain = ThePreference.Domain.Product.Color;
using ModelDomain = ThePreference.Domain.Product.Model;

namespace ThePreference.Infrastructure.Repository.Repositories.Product;

public class QueryProductRepository : IQueryProductRepository
{
    private readonly ProductContext _productContext;

    public QueryProductRepository(ProductContext productContext, IMapper mapper)
    {
        _productContext = productContext;
    }

    public async Task<Result<ProductDomain>> GetProduct(Guid id)
    {
        try
        {
            var product = await _productContext.Products.AsNoTracking()
                .Include(brand => brand.Brand)
                .Include(model => model.Model)
                .Select(product => new ProductDomain
                {
                    Id = product.Id,
                    Name = product.Name,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Brand = new BrandDomain
                    {
                        Id = product.BrandId,
                        Name = product.Brand.Name,
                        IsDeleted = product.Brand.IsDeleted
                    },
                    Model = product.Model != null
                        ? new ModelDomain
                        {
                            Id = product.Model.Id,
                            Name = product.Model.Name,
                        }
                        : null
                }).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return Result.Failure<ProductDomain>($"{nameof(ProductDomain)} with Id: '{id}' is not exist.");
            }

            var categories = await _productContext.ProductCategories.AsNoTracking()
                .Join(_productContext.Categories.AsNoTracking(),
                    productCategory => productCategory.CategoryId,
                    category => category.Id,
                    (productCategory, category) => new { productCategory, category })
                .Where(item => item.productCategory.ProductId == id)
                .Select(item => new CategoryDomain
                {
                    Id = item.category.Id,
                    Name = item.category.Name,
                    IsDeleted = item.category.IsDeleted
                })
                .ToListAsync();

            var images = await _productContext.Images.AsNoTracking()
                .Where(image => image.ProductId == id)
                .Select(image => new ImageDomain
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    AltText = image.AltText
                })
                .ToListAsync();

            var colors = await _productContext.ProductColors.AsNoTracking()
                .Join(_productContext.Colors.AsNoTracking(),
                    productColor => productColor.ColorId,
                    color => color.Id,
                    (productColor, color) => new { productColor, color })
                .Where(item => item.productColor.ProductId == id)
                .Select(item => new ColorDomain
                {
                    Id = item.color.Id,
                    IsBasic = item.color.IsBasic,
                    Name = item.color.Name,
                    Code = item.color.Code,
                    IsDeleted = item.color.IsDeleted
                })
                .ToListAsync();


            product.Categories = categories;
            product.Images = images;
            product.Colors = colors;

            return Result.Success(product);
        }
        catch (Exception ex)
        {
            return Result.Failure<ProductDomain>("Failed to fetch the product." + ex.Message);
        }
    }

    public async Task<Result<List<ProductDomain>>> GetAllProducts()
    {
        try
        {
            var products = await _productContext.Products.AsNoTracking()
                .Include(brand => brand.Brand)
                .Include(model => model.Model)
                .Select(product => new ProductDomain
                {
                    Id = product.Id,
                    Name = product.Name,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Brand = new BrandDomain
                    {
                        Id = product.BrandId,
                        Name = product.Brand.Name,
                        IsDeleted = product.Brand.IsDeleted
                    },
                    Model = product.Model != null
                        ? new ModelDomain
                        {
                            Id = product.Model.Id,
                            Name = product.Model.Name,
                        }
                        : null
                }).ToListAsync();

            var categories = await _productContext.ProductCategories.AsNoTracking()
                .Join(_productContext.Categories.AsNoTracking(),
                    productCategory => productCategory.CategoryId,
                    category => category.Id,
                    (productCategory, category) => new { productCategory, category })
                .Select(item => new CategoryDomain
                {
                    Id = item.category.Id,
                    Name = item.category.Name,
                    IsDeleted = item.category.IsDeleted
                })
                .ToListAsync();

            var images = await _productContext.Images.AsNoTracking()
                .Select(image => new ImageDomain
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    AltText = image.AltText
                })
                .ToListAsync();

            var colors = await _productContext.ProductColors.AsNoTracking()
                .Join(_productContext.Colors.AsNoTracking(),
                    productColor => productColor.ColorId,
                    color => color.Id,
                    (productColor, color) => new { productColor, color })
                .Select(item => new ColorDomain
                {
                    Id = item.color.Id,
                    IsBasic = item.color.IsBasic,
                    Name = item.color.Name,
                    Code = item.color.Code,
                    IsDeleted = item.color.IsDeleted
                })
                .ToListAsync();

            foreach (var product in products)
            {
                product.Categories = categories.Where(category => category.Id == product.Id).ToList();
                product.Images = images.Where(image => image.Id == product.Id).ToList();
                product.Colors = colors.Where(color => color.Id == product.Id).ToList();
            }

            return Result.Success(products);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<ProductDomain>>("Failed to fetch the list of products." + ex.Message);
        }
    }

    public async Task<Result<List<ProductDomain>>> GetProductsByBrand(Guid brandId)
    {
        try
        {
            var products = await _productContext.Products.AsNoTracking()
                .Include(brand => brand.Brand)
                .Include(model => model.Model)
                .Where(product => product.BrandId == brandId)
                .Select(product => new ProductDomain
                {
                    Id = product.Id,
                    Name = product.Name,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Brand = new BrandDomain
                    {
                        Id = product.BrandId,
                        Name = product.Brand.Name,
                        IsDeleted = product.Brand.IsDeleted
                    },
                    Model = product.Model != null
                        ? new ModelDomain
                        {
                            Id = product.Model.Id,
                            Name = product.Model.Name,
                        }
                        : null
                }).ToListAsync();

            var productIds = products.Select(product => product.Id).ToList();

            var categories = await _productContext.ProductCategories.AsNoTracking()
                .Join(_productContext.Categories.AsNoTracking(),
                    productCategory => productCategory.CategoryId,
                    category => category.Id,
                    (productCategory, category) => new { productCategory, category })
                .Where(item => productIds.Contains(item.productCategory.ProductId))
                .Select(item => new CategoryDomain
                {
                    Id = item.category.Id,
                    Name = item.category.Name,
                    IsDeleted = item.category.IsDeleted
                })
                .ToListAsync();

            var images = await _productContext.Images.AsNoTracking()
                .Where(image => productIds.Contains(image.ProductId))
                .Select(image => new ImageDomain
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    AltText = image.AltText
                })
                .ToListAsync();

            var colors = await _productContext.ProductColors.AsNoTracking()
                .Join(_productContext.Colors.AsNoTracking(),
                    productColor => productColor.ColorId,
                    color => color.Id,
                    (productColor, color) => new { productColor, color })
                .Where(item => productIds.Contains(item.productColor.ProductId))
                .Select(item => new ColorDomain
                {
                    Id = item.color.Id,
                    IsBasic = item.color.IsBasic,
                    Name = item.color.Name,
                    Code = item.color.Code,
                    IsDeleted = item.color.IsDeleted
                })
                .ToListAsync();

            foreach (var product in products)
            {
                product.Categories = categories.Where(category => category.Id == product.Id).ToList();
                product.Images = images.Where(image => image.Id == product.Id).ToList();
                product.Colors = colors.Where(color => color.Id == product.Id).ToList();
            }

            return Result.Success(products);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<ProductDomain>>("Failed to fetch the list of products by brand." + ex.Message);
        }
    }

    public async Task<Result<List<ProductDomain>>> GetProductsByCategory(Guid categoryId)
    {
        try
        {
            var categories = await _productContext.ProductCategories.AsNoTracking()
                .Join(_productContext.Categories.AsNoTracking(),
                    productCategory => productCategory.CategoryId,
                    category => category.Id,
                    (productCategory, category) => new { productCategory, category })
                .Where(item => item.category.Id == categoryId)
                .Select(item => new
                {
                    Category = new CategoryDomain
                    {
                        Id = item.category.Id,
                        Name = item.category.Name,
                        IsDeleted = item.category.IsDeleted
                    },

                    item.productCategory.ProductId
                })
                .ToListAsync();

            if (categories.Count == 0)
            {
                return Result.Success(new List<ProductDomain>());
            }

            var productIds = categories.Select(category => category.ProductId).ToList();

            var products = await _productContext.Products.AsNoTracking()
                .Include(brand => brand.Brand)
                .Include(model => model.Model)
                .Where(product => productIds.Contains(product.Id))
                .Select(product => new ProductDomain
                {
                    Id = product.Id,
                    Name = product.Name,
                    Title = product.Title,
                    Description = product.Description,
                    Price = product.Price,
                    Brand = new BrandDomain
                    {
                        Id = product.BrandId,
                        Name = product.Brand.Name,
                        IsDeleted = product.Brand.IsDeleted
                    },
                    Model = product.Model != null
                        ? new ModelDomain
                        {
                            Id = product.Model.Id,
                            Name = product.Model.Name,
                        }
                        : null
                }).ToListAsync();

            var images = await _productContext.Images.AsNoTracking()
                .Where(image => productIds.Contains(image.ProductId))
                .Select(image => new ImageDomain
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    AltText = image.AltText
                })
                .ToListAsync();

            var colors = await _productContext.ProductColors.AsNoTracking()
                .Join(_productContext.Colors.AsNoTracking(),
                    productColor => productColor.ColorId,
                    color => color.Id,
                    (productColor, color) => new { productColor, color })
                .Where(item => productIds.Contains(item.productColor.ProductId))
                .Select(item => new ColorDomain
                {
                    Id = item.color.Id,
                    IsBasic = item.color.IsBasic,
                    Name = item.color.Name,
                    Code = item.color.Code,
                    IsDeleted = item.color.IsDeleted
                })
                .ToListAsync();

            foreach (var product in products)
            {
                product.Categories = categories.Select(category => category.Category).ToList();
                product.Images = images.Where(image => image.Id == product.Id).ToList();
                product.Colors = colors.Where(color => color.Id == product.Id).ToList();
            }

            return Result.Success(products);
        }
        catch (Exception ex)
        {
            return Result.Failure<List<ProductDomain>>("Failed to fetch the list of products by brand." + ex.Message);
        }
    }
}