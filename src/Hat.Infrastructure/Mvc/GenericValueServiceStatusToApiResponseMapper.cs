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
            var response = new ApiResponse<T>(serviceResult.Value);
            if (serviceResult.Success && _requestMethod == HttpMethod.Get.Method)
            {
                return new OkObjectResult(response);
            }

            throw new NotImplementedException("This scenario is not supported.");
        }
    }
}