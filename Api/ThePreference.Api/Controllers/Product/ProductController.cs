using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ThePreference.Core.Application.DTO.ProductModels.Request;

namespace ThePreference.Api.Controllers.Product;

//[ApiVersion("1.0")]
[Route("api/product/")]
[ApiController]
public class ProductController: BaseApiController
{
    [HttpGet("{productId:guid}")]
    public async Task<IActionResult> FetchProduct(Guid productId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) =
                await Mediator.Send(new GetProductRequestModel(productId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch the product. Error: {ex}");
        }
    }
    
    [HttpGet("get-all")]
    public async Task<IActionResult> FetchAllProducts()
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) =
                await Mediator.Send(new GetAllProductsRequestModel());
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch all products. Error: {ex}");
        }
    }
    
    [HttpGet("get-by-brand/{brandId:guid}")]
    public async Task<IActionResult> FetchProductsByBrand(Guid brandId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) =
                await Mediator.Send(new GetProductsByBrandRequestModel(brandId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        { 
            throw new HttpRequestException($"I'm afraid we can't fetch products by brand. Error: {ex}");
        }
    }
    
    [HttpGet("get-by-category/{categoryId:guid}")]
    public async Task<IActionResult> FetchProductsByCategory(Guid categoryId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) =
                await Mediator.Send(new GetProductsByCategoryRequestModel(categoryId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch products by category. Error: {ex}");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequestModel createProductRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(createProductRequestModel);
           
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't create the product. Error: {ex}");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestModel updateProductRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(updateProductRequestModel);
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't update the product. Error: {ex}");
        }
    }
    
    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(new DeleteProductRequestModel(productId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't remove the product. Error: {ex}");
        }
    }
}