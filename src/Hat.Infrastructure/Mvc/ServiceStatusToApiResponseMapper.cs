using System;
using System.Collections.Generic;
using System.Net.Http;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Hat.Infrastructure.Mvc
{
    public class ServiceStatusToApiResponseMapper
    {
        private readonly string _requestMethod;

        public ServiceStatusToApiResponseMapper(string requestMethod)
        {
            _requestMethod = requestMethod;
        }
    
        public IStatusCodeActionResult Map(IServiceResult serviceResult)
        {
            var response = new ApiResponse(serviceResult.Status.Messages);
            return CreateResult(serviceResult.Status, response);
        }
        
        public IStatusCodeActionResult Map<T>(IServiceResult<T> serviceResult)
        {
            var response = new ApiResponse<T>(serviceResult.Status.Messages, serviceResult.Value);
            return CreateResult(serviceResult.Status, response);
        }

        private IStatusCodeActionResult CreateResult(Status status, ApiResponse response)
        {
            
            IStatusCodeActionResult result = null!;
            if (Status.IsOk(status) && _requestMethod == HttpMethod.Get.Method)
            {
                result = new OkObjectResult(response);
            }
            else if (Status.IsOk(status) && _requestMethod == HttpMethod.Post.Method)
            {
                result = new CreatedResult("", "");
            }
            else if (Status.IsOk(status) && _requestMethod == HttpMethod.Put.Method)
            {
                result = new NoContentResult();
            }
            else if (Status.IsOk(status) && _requestMethod == HttpMethod.Delete.Method)
            {
                result = new NoContentResult();
            }

            else if (result == null)
            {
                throw new NotImplementedException($"service status and request method pair is not mapped to the valid result. Status: {status.Key} ; Request method: {_requestMethod}");
            }
            return result;
        }
    } 
}