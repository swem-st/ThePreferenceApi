using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;
using ThePreference.Infrastructure.Repository.DataAccess;
using ColorDomain = ThePreference.Domain.Product.Color;

namespace ThePreference.Infrastructure.Repository.Repositories.Color;

public class QueryColorRepository : IQueryColorRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    // private readonly IMapper _mapper;

    public QueryColorRepository(ProductContext productContext)
    {
        _productContext = productContext;
        // _mapper = mapper;
    }

    public async Task<Result<ColorDomain>> GetColor(Guid id)
    {
        var color = await _productContext.Colors.AsNoTracking()
            .Select(color => new ColorDomain
            {
                Id = color.Id,
                IsBasic = color.IsBasic,
                Name = color.Name,
                Code = color.Code,
                IsDeleted = color.IsDeleted
            })
            .FirstOrDefaultAsync(color => color.Id == id);

        if (color == null)
        {
            return Result.Failure<ColorDomain>($"{nameof(ColorDomain)} with Id: '{id}' is not exist.");
        }

        return Result.Success(color);
    }

    public async Task<Result<List<ColorDomain>>> GetAllColors()
    {
        var colors = await _productContext.Colors.AsNoTracking()
            .Select(color => new ColorDomain
            {
                Id = color.Id,
                IsBasic = color.IsBasic,
                Name = color.Name,
                Code = color.Code,
                IsDeleted = color.IsDeleted
            })
            .ToListAsync();

        return Result.Success(colors);
    }
}