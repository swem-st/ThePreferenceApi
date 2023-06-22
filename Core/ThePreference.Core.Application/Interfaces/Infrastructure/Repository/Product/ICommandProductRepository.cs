using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Product;

public interface ICommandProductRepository
{
    Task<Result> CreateProduct(Domain.Product.Product request);
    Task<Result> UpdateProduct(Domain.Product.Product request);
    Task<Result> DeleteProduct(Guid productId);
}