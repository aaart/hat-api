using System;
using System.Net.Http;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Infrastructure.Mvc
{
    public class NoValueServiceStatusToApiResponseMapper
    {
        private readonly string _requestMethod;

        public NoValueServiceStatusToApiResponseMapper(string requestMethod)
        {
            _requestMethod = requestMethod;
        }

        public StatusCodeResult Map(IServiceResult serviceResult)
        {
            if (serviceResult.Success && _requestMethod == HttpMethod.Put.Method)
            {
                return new NoContentResult();
            }

            if (serviceResult.Success && _requestMethod == HttpMethod.Delete.Method)
            {
                return new NoContentResult();
            }

            throw new InvalidOperationException("This scenario is not supported.");
        }
    }
}