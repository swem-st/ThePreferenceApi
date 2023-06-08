using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Brand;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.DataModels.Product;
using BrandDomain = ThePreference.Domain.Product.Brand;

namespace ThePreference.Infrastructure.Repository.Repositories.Brand;

public class CommandBrandRepository : ICommandBrandRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    public CommandBrandRepository(ProductContext productContext, IMapper mapper)
    {
        _productContext = productContext;
        _mapper = mapper;
    }

    public async Task<Result> CreateBrand (BrandDomain request)
    { 
        var existingBrand = await _productContext.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(brand => brand.Name == request.Name);
        
        if (existingBrand != null)
        {
            return Result.Failure($"{nameof(Brand)} with name: '{request.Name}' already exist.");
        }
        
        var brandEntity = _mapper.Map<BrandEntity>(request);
        
        await _productContext.Brands.AddAsync(brandEntity);
        await _productContext.SaveChangesAsync();
        return Result.Success(request.Name);
    }

    public async Task<Result> UpdateBrand(BrandDomain request)
    {
        var existingBrand = await _productContext.Brands
            .AsNoTracking()
            .FirstOrDefaultAsync(brand => brand.Id == request.Id);
        
        if (existingBrand == null)
        {
            return Result.Failure($"{nameof(Brand)} with Id: '{request.Id}' does not exist.");
        }
        
        var brandWithSameName = await _productContext.Brands
            .AsNoTracking()
                .FirstOrDefaultAsync(brand => brand.Name == request.Name && brand.Id != request.Id);
        
        if (brandWithSameName != null)
        {
            return Result.Failure($"{nameof(Brand)} with name: '{request.Name}' already exist.");
        }
        
        existingBrand = _mapper.Map<BrandEntity>(request);
        
        _productContext.Brands.Update(existingBrand);
        await _productContext.SaveChangesAsync();
        return Result.Success(request.Name);
    }
    
    public async Task<Result> DeleteBrand(Guid brandId)
    {
        var existingBrand = await _productContext.Brands.FirstOrDefaultAsync(brand => brand.Id == brandId);
        if (existingBrand == null)
        {
            return Result.Failure($"{nameof(Brand)} with Id: '{brandId}' does not exist.");
        }
        
        _productContext.Brands.Remove(existingBrand);
        await _productContext.SaveChangesAsync();
        return Result.Success(existingBrand.Name);
    }
}