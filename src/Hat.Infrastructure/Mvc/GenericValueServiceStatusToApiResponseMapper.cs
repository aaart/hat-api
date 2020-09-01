using System;
using System.IO;
using System.Net.Http;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Infrastructure.Mvc
{
    public class GenericValueServiceStatusToApiResponseMapper
    {
        private readonly string _requestMethod;

        public GenericValueServiceStatusToApiResponseMapper(string requestMethod)
        {
            _requestMethod = requestMethod;
        }

        public ObjectResult Map<T>(IServiceResult<T> serviceResult)
        {
            if (_requestMethod != HttpMethod.Get.Method)
            {
                throw new InvalidOperationException($"{_requestMethod} http method is not supported.");
            }
            
            if (serviceResult.Success)
            {
                var response = new ApiResponse<T>(serviceResult.Value);
                return new OkObjectResult(response);
            }

            var majorError = serviceResult.Errors[0];
            var errorResponse = new ApiErrorResponse(serviceResult.Errors);
            if (Error.IsNotFound(majorError))
            {
                return new NotFoundObjectResult(errorResponse);
            }
            if (Error.IsUnauthorized(majorError))
            {
                return new UnauthorizedObjectResult(errorResponse);
            }
            
            return new ObjectResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}