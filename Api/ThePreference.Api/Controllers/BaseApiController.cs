using System.Net;
using Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ThePreference.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        protected IActionResult HandleResult<TValue>(bool isSuccess, TValue value, string error)
        {
            return isSuccess
                ? new JsonResult(value)
                {
                    StatusCode = (int)HttpStatusCode.OK
                }
                : new JsonResult(error)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
        }

        //For future development we can use this method to log the error. Using ILogger...
        protected string GetErrorMessage(ActionLog actionLog, string type, string error)
        {
            return $"There is some error occurred on {actionLog} {type}. Reason: {error}";
        }
    }
}