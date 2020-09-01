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
        private readonly ErrorToResponseMapper _errorMapper;

        public GenericValueServiceStatusToApiResponseMapper(string requestMethod)
        {
            _requestMethod = requestMethod;
            _errorMapper = new ErrorToResponseMapper();
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

            return _errorMapper.Map(serviceResult.Errors);
        }
    }
}