using System.ComponentModel;
using Microsoft.AspNetCore.HttpOverrides;

namespace Hat.Infrastructure.Mvc
{
    public class PagingRequest
    {
        [DefaultValue(1)]
        public int Page { get; set; } = 1;
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;
    }
}