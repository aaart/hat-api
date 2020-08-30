using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Hat.Infrastructure.Service
{
    public class ServiceResult : IServiceResult
    {
        public static IServiceResult SuccessResult() => new ServiceResult(true, new Error[0]); 
        public static IServiceResult FailedResult(Error[] errors) => new ServiceResult(false, errors); 
        
        protected ServiceResult(bool success, Error[] errors)
        {
            Success = success;
            Errors = errors;
        }

        public bool Success { get; }
        public Error[] Errors { get; }
    }

    public class ServiceResult<T> : ServiceResult, IServiceResult<T>
    {
        private readonly T _value;
        public static IServiceResult<T> SuccessResult(T value) => new ServiceResult<T>(true, new Error[0], value); 
        public new static IServiceResult<T> FailedResult(Error[] errors) => new ServiceResult<T>(false, errors); 
        
        private ServiceResult(bool success, Error[] errors, T value = default!)
            : base(success, errors)
        {
            _value = value;
        }

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