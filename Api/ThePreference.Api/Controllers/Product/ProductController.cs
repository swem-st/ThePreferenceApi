using Microsoft.AspNetCore.Mvc;
using ThePreference.Application.DTO.ProductModels.Response;

namespace ThePreference.Api.Controllers.Product;


[Route("api/product/")]
[ApiController]
public class ProductController: ControllerBase
{
    [HttpGet("get-products-by-category/{categoryId:guid}")]
    public async Task<ICollection<ProductListResponseModel>> FetchProducts(Guid categoryId)
    {
        try
        {
            var result = await _queryTimetableModelService.FetchProductsByCategory(categoryId);

            return result;
        }
        catch (Exception ex)
        { 
            
            throw new HttpRequestException("I'm afraid we can't fetch the list of product");
        }
    }
    
    [HttpGet("product-by-id/{id}")]
    public async Task<ProductResponseModel> FetchProduct(Guid id)
    {
        try
        {
            var result = await _queryTimetableModelService.FetchProductById(id);

            return result;
        }
        catch (Exception ex)
        { 
            
            throw new HttpRequestException("I'm afraid we can't fetch the product");
        }
    }
}