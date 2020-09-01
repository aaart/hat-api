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
        private readonly ErrorToResponseMapper _errorMapper;

        public NoValueServiceStatusToApiResponseMapper(string requestMethod)
        {
            _requestMethod = requestMethod;
            _errorMapper = new ErrorToResponseMapper();
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

            return _errorMapper.Map(serviceResult.Errors);
        }
    }
}