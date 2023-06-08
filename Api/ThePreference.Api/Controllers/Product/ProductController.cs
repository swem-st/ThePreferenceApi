using Microsoft.AspNetCore.Mvc;
using ThePreference.Application.DTO.ProductModels.Request;

namespace ThePreference.Api.Controllers.Product;

//[ApiVersion("1.0")]
[Route("api/product/")]
[ApiController]
public class ProductController: BaseApiController
{
    [HttpGet("get-products-by-category/{categoryId:guid}")]
    public async Task<IActionResult> FetchProducts(Guid categoryId)
    {
        try
        {
            var result =await Mediator.Send(new GetProductsByCategoryRequestModel(categoryId));
            
            return this.Ok(result);
        }
        catch (Exception ex)
        { 
            
            throw new HttpRequestException("I'm afraid we can't fetch the list of product");
        }
    }
    
    [HttpGet("product-by-id/{productId:guid}")]
    public async Task<IActionResult> FetchProduct(Guid productId)
    {
        try
        {
            var result =await Mediator.Send(new GetProductRequestModel(productId));
            
            return this.Ok(result);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException("I'm afraid we can't fetch the product");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequestModel createProductRequestModel)
    {
        try
        {
            var result =await Mediator.Send(createProductRequestModel);
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException("I'm afraid we can't fetch the product");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestModel updateProductRequestModel)
    {
        try
        {
            var result =await Mediator.Send(updateProductRequestModel);
            
            return this.Ok(result);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException("I'm afraid we can't fetch the product");
        }
    }
    
    [HttpDelete("product-by-id/{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        try
        {
            var result =await Mediator.Send(new DeleteProductRequestModel(productId));
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException("I'm afraid we can't fetch the product");
        }
    }
}