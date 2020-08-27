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
            if (Status.IsOk(serviceResult.Status) && _requestMethod == HttpMethod.Put.Method)
            {
                return new NoContentResult();
            }

            if (Status.IsOk(serviceResult.Status) && _requestMethod == HttpMethod.Delete.Method)
            {
                return new NoContentResult();
            }

            throw new InvalidOperationException($"service status and request method pair is not mapped to the valid result. Status: {serviceResult.Status.Key} ; Request method: {_requestMethod}");
        }
    }
}