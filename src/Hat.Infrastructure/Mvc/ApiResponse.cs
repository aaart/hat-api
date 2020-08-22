using System.Collections.Generic;

namespace Hat.Infrastructure.Mvc
{
    public class ApiResponse
    {
        public ApiResponse(IEnumerable<string> info)
        {
            Info = info;
        }
        public IEnumerable<string> Info { get; }
    }
    
    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(IEnumerable<string> info, T data)
            : base(info)
        {
            Data = data;
        }
        public T Data { get; }
    }
}