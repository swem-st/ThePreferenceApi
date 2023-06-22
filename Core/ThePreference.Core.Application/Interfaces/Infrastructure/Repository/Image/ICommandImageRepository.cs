using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;

public interface ICommandImageRepository
{
    Task<Result> CreateImage(Domain.Product.Image request);
    Task<Result> UpdateImage(Domain.Product.Image request);
    Task<Result> DeleteImage(Guid imageId);
}