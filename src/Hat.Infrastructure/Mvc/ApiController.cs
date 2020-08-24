using System;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Infrastructure.Mvc
{
    public class ApiController : ControllerBase
    {
        protected IActionResult CreateResponse(IServiceResult result)
        {
            var mapper = new NoValueServiceStatusToApiResponseMapper(HttpContext.Request.Method);
            return mapper.Map(result);
        }

        protected IActionResult CreateResponse<T>(IServiceResult<T> result)
        {
            var mapper = new GenericValueServiceStatusToApiResponseMapper(HttpContext.Request.Method);
            return mapper.Map(result);
        }
        
        protected IActionResult CreateResponse<TId>(IResourceCreatedServiceResult<TId> result)
        {
            var mapper = new ResourceCreatedServiceStatusToApiResponseMapper(HttpContext.Request.Method);
            return mapper.Map(result);
        }
    }
}