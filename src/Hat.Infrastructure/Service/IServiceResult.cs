using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hat.Infrastructure.Service
{
    public interface IServiceResult
    {
        public bool Success { get; }
        public Status Status { get; }
    }

    public interface IServiceResult<out T> : IServiceResult
    {
        public T Value { get; }
    }
}