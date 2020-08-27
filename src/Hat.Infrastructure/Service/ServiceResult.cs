using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Hat.Infrastructure.Service
{
    public class ServiceResult : IServiceResult
    {
        public static IServiceResult SuccessResult() => new ServiceResult(true); 
        public static IServiceResult FailedResult() => new ServiceResult(false); 
        
        private ServiceResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }

    public class ServiceResult<T> : IServiceResult<T>
    {
        private readonly T _value;
        public static IServiceResult<T> SuccessResult(T value) => new ServiceResult<T>(true, value); 
        public static IServiceResult<T> FailedResult() => new ServiceResult<T>(false); 
        
        private ServiceResult(bool success, T value = default!)
        {
            Success = success;
            _value = value;
        }

        public bool Success { get; }

        public T Value
        {
            get
            {
                if (Success)
                {
                    return _value;
                }
                throw new InvalidOperationException("Could not extract result value because service execution failed.");
            }
        }
    } 
}