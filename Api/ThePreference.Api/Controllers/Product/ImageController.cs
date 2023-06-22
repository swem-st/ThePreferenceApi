using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ThePreference.Core.Application.DTO.BrandModels.Request;
using ThePreference.Core.Application.DTO.ImageModels.Request;

namespace ThePreference.Api.Controllers.Product;

[Route("api/image/")]
[ApiController]
public class ImageController: BaseApiController
{
    [HttpGet("{imageId:guid}")]  
    public async Task<IActionResult> FetchImage(Guid imageId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) = 
                await Mediator.Send(new GetImageRequestModel(imageId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch the image. Error: {ex}");
        }
    }
    
    [HttpGet("get-all")]  
    public async Task<IActionResult> FetchAllImages()
    {
        try
        {
            //TODO: Need to add validation - Only super admin can fetch all images.
            (bool isSuccess, bool isFailure, var value, string error) = 
                await Mediator.Send(new GetAllImagesRequestModel());
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch all images. Error: {ex}");
        }
    }
    
    [HttpGet("get-by-product/{productId:guid}")]
    public async Task<IActionResult> FetchImagesByProduct(Guid productId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) =
                await Mediator.Send(new GetImagesByProductRequestModel(productId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        { 
            throw new HttpRequestException($"I'm afraid we can't fetch images by product id: {productId}. Error: {ex}");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateImage(CreateImageRequestModel createImageRequestModel)
    {
        try
        {
            //TODO: Need to add validation - Only super admin can create image (user can create image when he is creating Product).
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(createImageRequestModel);

            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't create the image. Error: {ex}");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateImage(UpdateImageRequestModel updateImageRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(updateImageRequestModel);
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't update the image. Error: {ex}");
        }
    }
    
    [HttpDelete("{imageId:guid}")]
    public async Task<IActionResult> DeleteImage(Guid imageId)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(new DeleteImageRequestModel(imageId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't remove the image. Error: {ex}");
        }
    }
}