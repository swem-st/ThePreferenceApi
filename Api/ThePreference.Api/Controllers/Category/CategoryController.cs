using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ThePreference.Core.Application.DTO.CategoryModels.Request;

namespace ThePreference.Api.Controllers.Category;

[Route("api/category/")]
[ApiController]
public class CategoryController: BaseApiController
{
    [HttpGet("{categoryId:guid}")]
    public async Task<IActionResult> FetchCategory(Guid categoryId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) =
                await Mediator.Send(new GetCategoryRequestModel(categoryId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch the category. Error: {ex}");
        }
    }
    
    [HttpGet("get-all-category")]
    public async Task<IActionResult> FetchAllCategory()
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) =
                await Mediator.Send(new GetAllCategoryRequestModel());
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch all category. Error: {ex}");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel createCategoryRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(createCategoryRequestModel);
           
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't create the category. Error: {ex}");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestModel updateCategoryRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) =await Mediator.Send(updateCategoryRequestModel);
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't update the category. Error: {ex}");
        }
    }
    
    [HttpDelete("{categoryId:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(new DeleteCategoryRequestModel(categoryId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't remove the category. Error: {ex}");
        }
    }
}