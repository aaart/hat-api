using System;
using System.Net.Http;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Infrastructure.Mvc
{
    public class ResourceCreatedServiceStatusToApiResponseMapper
    {
        private readonly string _requestMethod;
        private readonly string _resourceDirectory;

        public ResourceCreatedServiceStatusToApiResponseMapper(string requestMethod, string resourceDirectory)
        {
            _requestMethod = requestMethod;
            _resourceDirectory = resourceDirectory;
        }

        public ObjectResult Map<TId>(IResourceCreatedServiceResult<TId> serviceResult)
        {
            if (_requestMethod != HttpMethod.Post.Method)
            {
                throw new InvalidOperationException($"{_requestMethod} http method is not supported.");
            }
            
            var response = new ResourceCreatedApiResponse<TId>(serviceResult.Id);
            if (serviceResult.Success)
            {
                return new CreatedResult($"{_resourceDirectory}/{serviceResult.Id}", response);
            }

            var majorError = serviceResult.Errors[0];
            var errorResponse = new ApiErrorResponse(serviceResult.Errors);
            return new ObjectResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}