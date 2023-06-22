using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;

public interface IQueryProductRepository
{
    Task<Result<Domain.Product.Product>> GetProduct(Guid id);
    Task<Result<List<Domain.Product.Product>>> GetAllProducts();
    Task<Result<List<Domain.Product.Product>>> GetProductsByBrand(Guid brandId);
    //Maybe In the future we need to get products by categories (LIST OF CATEGORies !!!) or categories should have parent categoryID
    Task<Result<List<Domain.Product.Product>>> GetProductsByCategory(Guid categoryId);
}