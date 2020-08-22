using System;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Infrastructure.Mvc
{
    public class HatApiController : ControllerBase
    {
        protected IActionResult CreateResponse(IServiceResult result)
        {
            var mapper = new ServiceStatusToApiResponseMapper(HttpContext.Request.Method);
            return mapper.Map(result);
        }

        protected IActionResult CreateResponse<T>(IServiceResult<T> result)
        {
            return Ok();
        }
    }
}