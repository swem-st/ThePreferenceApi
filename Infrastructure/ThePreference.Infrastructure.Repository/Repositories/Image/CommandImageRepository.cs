using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;
using ThePreference.Infrastructure.Repository.DataAccess;
using ThePreference.Infrastructure.Repository.DataModels.Product;
using ImageDomain = ThePreference.Domain.Product.Image;

namespace ThePreference.Infrastructure.Repository.Repositories.Image;

public class CommandImageRepository : ICommandImageRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;

    public CommandImageRepository(ProductContext productContext, IMapper mapper)
    {
        _productContext = productContext;
        _mapper = mapper;
    }
    
    public async Task<Result> CreateImage(ImageDomain request)
    {
        var existingProduct = await _productContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(product => product.Id == request.ProductId);

        if (existingProduct == null)
        {
            return Result.Failure($"{nameof(Product)} with Id: '{request.ProductId}' does not exist.");
        }

        var imageEntity = _mapper.Map<ImageEntity>(request);
        
        await _productContext.Images.AddAsync(imageEntity);
        await _productContext.SaveChangesAsync();
        return Result.Success(request.ImageUrl);
    }

    public async Task<Result> UpdateImage(ImageDomain request)
    {
        var existingImage = await _productContext.Images
            .AsNoTracking()
            .FirstOrDefaultAsync(image => image.Id == request.Id);
        
        if (existingImage == null)
        {
            return Result.Failure($"{nameof(Image)} with Id: '{request.Id}' does not exist.");
        }
        
        _mapper.Map(request, existingImage);
        
        _productContext.Images.Update(existingImage);
        await _productContext.SaveChangesAsync();
        return Result.Success(request.ImageUrl);
    }

    public async Task<Result> DeleteImage(Guid imageId)
    {
        var existingImage = await _productContext.Images.FirstOrDefaultAsync(image => image.Id == imageId);
        if (existingImage == null)
        {
            return Result.Failure($"{nameof(Image)} with Id: '{imageId}' does not exist.");
        }
        
        _productContext.Images.Remove(existingImage);
        await _productContext.SaveChangesAsync();
        return Result.Success(existingImage.ImageUrl);
    }
}