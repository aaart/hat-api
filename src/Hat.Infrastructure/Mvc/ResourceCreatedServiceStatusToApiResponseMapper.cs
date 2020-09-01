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
            var response = new ResourceCreatedApiResponse<TId>(serviceResult.Id);
            if (serviceResult.Success && _requestMethod == HttpMethod.Post.Method)
            {
                return new CreatedResult($"{_resourceDirectory}/{serviceResult.Id}", serviceResult.Id);
            }

            throw new InvalidOperationException("This scenario is not supported.");
        }
    }
}