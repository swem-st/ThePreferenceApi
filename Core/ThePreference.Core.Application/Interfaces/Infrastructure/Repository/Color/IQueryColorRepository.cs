using CSharpFunctionalExtensions;

namespace ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;

public interface IQueryColorRepository
{
    Task<Result<Domain.Product.Color>> GetColor(Guid id);
    Task<Result<List<Domain.Product.Color>>> GetAllColors();
}