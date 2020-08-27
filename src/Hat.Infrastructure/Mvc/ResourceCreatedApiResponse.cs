using System.Collections.Generic;

namespace Hat.Infrastructure.Mvc
{
    public class ResourceCreatedApiResponse<TId> : ApiResponse
    {
        public ResourceCreatedApiResponse(TId id, IEnumerable<string> info) 
            : base(info)
        {
        }
        
        public TId Id { get; set; }
    }
}