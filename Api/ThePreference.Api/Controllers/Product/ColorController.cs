using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ThePreference.Core.Application.DTO.ColorModels.Request;

namespace ThePreference.Api.Controllers.Product;

[Route("api/color/")]
[ApiController]
public class ColorController: BaseApiController
{
    [HttpGet("{colorId:guid}")]  
    public async Task<IActionResult> FetchColor(Guid colorId)
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) = 
                await Mediator.Send(new GetColorRequestModel(colorId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch the color. Error: {ex}");
        }
    }
    
    [HttpGet("get-all")]  
    public async Task<IActionResult> FetchAllColors()
    {
        try
        {
            (bool isSuccess, bool isFailure, var value, string error) = 
                await Mediator.Send(new GetAllColorsRequestModel());
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, value, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't fetch all colors. Error: {ex}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateColor(CreateColorRequestModel createColorRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(createColorRequestModel);

            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't create the color. Error: {ex}");
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateColor(UpdateColorRequestModel updateColorRequestModel)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(updateColorRequestModel);
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't update the color. Error: {ex}");
        }
    }
    
    [HttpDelete("{colorId:guid}")]
    public async Task<IActionResult> DeleteColor(Guid colorId)
    {
        try
        {
            (bool isSuccess, bool isFailure, string error) = await Mediator.Send(new DeleteColorRequestModel(colorId));
            
            if (isFailure)
            {
                //logger
            }
            
            return HandleResult(isSuccess, isSuccess, !isSuccess ? error : string.Empty);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"I'm afraid we can't remove the color. Error: {ex}");
        }
    }
}