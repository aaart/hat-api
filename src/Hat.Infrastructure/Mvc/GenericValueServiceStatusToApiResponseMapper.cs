using System;
using System.Net.Http;
using Hat.Infrastructure.Service;
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
            var response = new ApiResponse<T>(serviceResult.Status.Messages, serviceResult.Value);
            if (Status.IsOk(serviceResult.Status) && _requestMethod == HttpMethod.Get.Method)
            {
                return new OkObjectResult(response);
            }

            throw new InvalidOperationException($"service status and request method pair is not mapped to the valid result. Status: {serviceResult.Status.Key} ; Request method: {_requestMethod}");
        }
    }
}