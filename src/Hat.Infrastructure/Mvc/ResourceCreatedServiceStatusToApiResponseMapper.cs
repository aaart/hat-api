using System;
using System.Net.Http;
using Hat.Infrastructure.Service;
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

        public CreatedResult Map<TId>(IResourceCreatedServiceResult<TId> serviceResult)
        {
            var response = new ApiResponse<TId>(serviceResult.Status.Messages, serviceResult.Id);
            if (Status.IsOk(serviceResult.Status) && _requestMethod == HttpMethod.Post.Method)
            {
                return new CreatedResult($"{_resourceDirectory}/{serviceResult.Id}", serviceResult.Id);
            }

            throw new InvalidOperationException($"service status and request method pair is not mapped to the valid result. Status: {serviceResult.Status.Key} ; Request method: {_requestMethod}");
        }
    }
}