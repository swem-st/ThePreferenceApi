using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Color;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.DataModels.Product;
using ColorDomain = ThePreference.Domain.Product.Color;

namespace ThePreference.Infrastructure.Repository.Repositories.Color;

public class CommandColorRepository : ICommandColorRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    public CommandColorRepository(ProductContext productContext, IMapper mapper)
    {
        _productContext = productContext;
        _mapper = mapper;
    }

    public async Task<Result> CreateColor(ColorDomain request)
    {
        //TODO: Add validation for request. Only superAdmin can create basic color
        var existingBasicColor = await _productContext.Colors
            .AsNoTracking()
            .FirstOrDefaultAsync(color => color.Name == request.Name && color.IsBasic == true);
        
        if (existingBasicColor != null)
        {
            if (existingBasicColor.IsDeleted)
            {
                existingBasicColor.IsDeleted = false;
                existingBasicColor.Code = request.Code;
                _productContext.Colors.Update(existingBasicColor);
                await _productContext.SaveChangesAsync();
                return Result.Success(request.Name);
            }
            return Result.Failure($"Basic {nameof(Color)} with name: '{request.Name}' already exist.");
        }
        
        var colorEntity = _mapper.Map<ColorEntity>(request);
        await _productContext.Colors.AddAsync(colorEntity);
        
        await _productContext.SaveChangesAsync();
        return Result.Success(request.Name);
    }

    public async Task<Result> UpdateColor(ColorDomain request)
    {
        //TODO: Add validation for request. Only superAdmin can update basic color
        var existingColor = await _productContext.Colors
            .AsNoTracking()
            .FirstOrDefaultAsync(color => color.Id == request.Id && !color.IsDeleted);
        
        if (existingColor == null)
        {
            return Result.Failure($"{nameof(Color)} with Id: '{request.Id}' does not exist.");
        }

        if (request.IsBasic)
        {
            var basicColorWithSameName = await _productContext.Colors
                .AsNoTracking()
                .FirstOrDefaultAsync(color => 
                    color.Name == request.Name &&
                    color.IsBasic == true &&
                    color.Id != request.Id );
        
            if (basicColorWithSameName != null)
            {
                var error = basicColorWithSameName.IsDeleted ? "have been removed, please restore it first" : "already exist";
            
                return Result.Failure($"Basic {nameof(Color)} with name: '{request.Name}' {error}.");
            }
        }
        
        _mapper.Map(request, existingColor);
        
        _productContext.Colors.Update(existingColor);
        await _productContext.SaveChangesAsync();
        return Result.Success(request.Name);
    }

    public async Task<Result> DeleteColor(Guid colorId)
    {
        //TODO: Add validation for request. Only superAdmin can delete basic colors
        var existingColor = await _productContext.Colors.FirstOrDefaultAsync(color => color.Id == colorId && !color.IsDeleted);
        if (existingColor == null)
        {
            return Result.Failure($"{nameof(Color)} with Id: '{colorId}' does not exist.");
        }
        
        _productContext.Colors.Remove(existingColor);
        await _productContext.SaveChangesAsync();
        return Result.Success(existingColor.Name);
    }
}