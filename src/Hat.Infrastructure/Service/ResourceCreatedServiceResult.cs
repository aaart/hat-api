using System;

namespace Hat.Infrastructure.Service
{
    public class ResourceCreatedServiceResult<TId> : IResourceCreatedServiceResult<TId>
    {
        private readonly TId _id;
        public static IResourceCreatedServiceResult<TId> SuccessResult(TId id) => new ResourceCreatedServiceResult<TId>(true, new Error[0], id); 
        public static IResourceCreatedServiceResult<TId> FailedResult(Error[] errors) => new ResourceCreatedServiceResult<TId>(false, errors); 
        
        private ResourceCreatedServiceResult(bool success, Error[] errors, TId id = default!)
        {
            Success = success;
            Errors = errors;
            _id = id;
        }

        public bool Success { get; }
        public Error[] Errors { get; }

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