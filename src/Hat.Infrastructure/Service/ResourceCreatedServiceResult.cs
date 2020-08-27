using System;

namespace Hat.Infrastructure.Service
{
    public class ResourceCreatedServiceResult<TId> : IResourceCreatedServiceResult<TId>
    {
        private readonly TId _id;
        public static IResourceCreatedServiceResult<TId> SuccessResult(TId id) => new ResourceCreatedServiceResult<TId>(true, id); 
        public static IResourceCreatedServiceResult<TId> FailedResult() => new ResourceCreatedServiceResult<TId>(false); 
        
        private ResourceCreatedServiceResult(bool success, TId id = default!)
        {
            Success = success;
            _id = id;
        }

        public bool Success { get; }

        public TId Id
        {
            get
            {
                if (Success)
                {
                    return _id;
                }
                throw new InvalidOperationException("Could not extract result value because service execution failed.");
            }
        }
    }
}