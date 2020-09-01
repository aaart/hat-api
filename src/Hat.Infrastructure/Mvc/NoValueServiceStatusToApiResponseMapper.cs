using System;
using System.Net.Http;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Hat.Infrastructure.Mvc
{
    public class NoValueServiceStatusToApiResponseMapper
    {
        private readonly string _requestMethod;

        public NoValueServiceStatusToApiResponseMapper(string requestMethod)
        {
            _requestMethod = requestMethod;
        }

        public IStatusCodeActionResult Map(IServiceResult serviceResult)
        {
            if (_requestMethod == HttpMethod.Put.Method && _requestMethod == HttpMethod.Delete.Method)
            {
                throw new InvalidOperationException($"{_requestMethod} http method is not supported.");
            }
            
            if (serviceResult.Success)
            {
                return new NoContentResult();
            }
            
            var majorError = serviceResult.Errors[0];
            var errorResponse = new ApiErrorResponse(serviceResult.Errors);
            return new ObjectResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}