using Microsoft.AspNetCore.HttpOverrides;

namespace Hat.Infrastructure.Mvc
{
    public class PagingRequest
    {
        public PagingRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; }
        public int PageSize { get; }
    }
}