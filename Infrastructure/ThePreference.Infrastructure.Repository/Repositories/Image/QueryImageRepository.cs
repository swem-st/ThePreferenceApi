using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ThePreference.Core.Application.Interfaces.Infrastructure.Repository.Image;
using ThePreference.Infrastructure.Repository.DataAccess;
using ImageDomain = ThePreference.Domain.Product.Image;

namespace ThePreference.Infrastructure.Repository.Repositories.Image;

public class QueryImageRepository : IQueryImageRepository
{
    //Basically it should be Interface of ProductContext in (the Infrastructure(Application) layer)
    //cause it's will be make easier to test and we will be follow DDD principles
    private readonly ProductContext _productContext;
    // private readonly IMapper _mapper;

    public QueryImageRepository(ProductContext productContext)
    {
        _productContext = productContext;
        // _mapper = mapper;
    }
    
    public async Task<Result<ImageDomain>> GetImage(Guid id)
    {
        var image = await _productContext.Images.AsNoTracking()
            .Select(image => new ImageDomain
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                AltText = image.AltText,
            })
            .FirstOrDefaultAsync(image => image.Id == id);

        if (image == null)
        {
            return Result.Failure<ImageDomain>($"{nameof(ImageDomain)} with Id: '{id}' is not exist.");
        }

        return Result.Success(image);
    }

    public async Task<Result<List<ImageDomain>>> GetAllImages()
    {
        var images = await _productContext.Images.AsNoTracking()
            .Select(image => new ImageDomain
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                AltText = image.AltText,
            })
            .ToListAsync();

        return Result.Success(images);
    }
    
    public async Task<Result<List<ImageDomain>>> GetImagesByProduct(Guid productId)
    {
        var images = await _productContext.Images.AsNoTracking()
            .Where(image => image.ProductId == productId)
            .Select(image => new ImageDomain
            {
                Id = image.Id,
                ImageUrl = image.ImageUrl,
                AltText = image.AltText,
            })
            .ToListAsync();

        return Result.Success(images);
    }
}