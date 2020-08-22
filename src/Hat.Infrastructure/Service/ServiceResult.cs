using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Hat.Infrastructure.Service
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult()
        {
            Status = Status.Ok;
        }
        
        public ServiceResult(Status status)
        {
            Status = status;
        }
        
        public bool Success => Service.Status.IsOk(Status);
        public Status Status { get; }
    }

    public class ServiceResult<T> : ServiceResult, IServiceResult<T>
    {
        public ServiceResult(T value)
        {
            Value = value;
        }

        public ServiceResult(Status status)
            : base(status)
        {
        }
        
        public T Value { get; } = default!;
    } 
}