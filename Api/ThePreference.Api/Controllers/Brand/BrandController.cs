using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ThePreference.Core.Application.DTO.BrandModels.Request;

namespace ThePreference.Api.Controllers.Brand;

[Route("api/brand/")]
[ApiController]
public class BrandController: BaseApiController
{
    [HttpGet("{brandId:guid}")]  
    public async Task<IActionResult> FetchBrand(Guid brandId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) = 
                await Mediator.Send(new GetBrandRequestModel(brandId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch the brand. Error: {ex}");
        }
    }
    
    [HttpGet("get-all-brand")]  
    public async Task<IActionResult> FetchAllBrand()
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) = 
                await Mediator.Send(new GetAllBrandRequestModel());
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch all brands. Error: {ex}");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandRequestModel createBrandRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(createBrandRequestModel);

            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't create the brand. Error: {ex}");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandRequestModel updateBrandRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(updateBrandRequestModel);
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't update the brand. Error: {ex}");
        }
    }
    
    [HttpDelete("{brandId:guid}")]
    public async Task<IActionResult> DeleteBrand(Guid brandId)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(new DeleteBrandRequestModel(brandId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't remove the brand. Error: {ex}");
        }
    }
}