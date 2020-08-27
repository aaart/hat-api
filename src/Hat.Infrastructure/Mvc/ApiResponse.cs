using System.Collections.Generic;

namespace Hat.Infrastructure.Mvc
{
    public class ApiResponse
    {
    }
    
    public class ApiResponse<T> : ApiResponse
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; }
    }
}