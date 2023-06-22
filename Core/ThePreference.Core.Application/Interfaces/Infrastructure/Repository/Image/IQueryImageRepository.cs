using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;

public interface IQueryImageRepository
{
    Task<Result<Domain.Product.Image>> GetImage(Guid id);
    Task<Result<List<Domain.Product.Image>>> GetAllImages();
    Task<Result<List<Domain.Product.Image>>> GetImagesByProduct(Guid productId);
}