using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;
using ThePreference.Infrastructure.Repository.DataAccess;
using BrandDomain = ThePreference.Domain.Product.Brand;

namespace ThePreference.Infrastructure.Repository.Repositories.Brand;

public class QueryBrandRepository : IQueryBrandRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    // private readonly IMapper _mapper;

    public QueryBrandRepository(ProductContext productContext)
    {
        _productContext = productContext;
        // _mapper = mapper;
    }

    public async Task<Result<BrandDomain>> GetBrand(Guid id)
    {
        var brandEntity = await _productContext.Brands.AsNoTracking()
            .Select(brand => new BrandDomain
            {
                Id = brand.Id,
                Name = brand.Name
            })
            .FirstOrDefaultAsync(brand => brand.Id == id);

        if (brandEntity == null)
        {
            return Result.Failure<BrandDomain>($"{nameof(BrandDomain)} with Id: '{id}' is not exist.");
        }

        return Result.Success(brandEntity);
    }
}