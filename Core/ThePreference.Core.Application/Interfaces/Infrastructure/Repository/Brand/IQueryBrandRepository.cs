using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;

public interface IQueryBrandRepository
{
    Task<Result<Domain.Product.Brand>> GetBrand(Guid id);
    Task<Result<List<Domain.Product.Brand>>> GetAllBrands();
}