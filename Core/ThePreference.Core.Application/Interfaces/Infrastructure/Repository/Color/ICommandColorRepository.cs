using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;

public interface ICommandColorRepository
{
    Task<Result> CreateColor(Domain.Product.Color request);
    Task<Result> UpdateColor(Domain.Product.Color request);
    Task<Result> DeleteColor(Guid colorId);
}