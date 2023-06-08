using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;

public interface ICommandBrandRepository
{
    Task<Result> CreateBrand(Domain.Product.Brand request);
    Task<Result> UpdateBrand(Domain.Product.Brand request);
    Task<Result> DeleteBrand(Guid brandId);
}