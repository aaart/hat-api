using System;
using System.IO;
using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class GenericValueServiceStatusToApiResponseMapperTest
    {
        [Theory]
        [InlineData("GET", StatusCodes.Status200OK)]
        public void GivenSuccess_WhenTypedResult_ExpectValidHttpResponse(string requestMethod, int expectedCode)
        {
            var mapper = new GenericValueServiceStatusToApiResponseMapper(requestMethod);
            var result = mapper.Map(ServiceResult<object>.SuccessResult(new object()));
            Assert.Equal(expectedCode, result.StatusCode);
        }
        
        [Theory]
        [InlineData("GET")]
        public void GivenSuccess_WhenTypedResult_ExpectApiResponseType(string requestMethod)
        {
            var mapper = new GenericValueServiceStatusToApiResponseMapper(requestMethod);
            var result = mapper.Map(ServiceResult<object>.SuccessResult(new object()));
            Assert.IsType<ApiResponse<object>>(result.Value);
        }
        
        [Theory]
        [InlineData("GET", typeof(FileNotFoundException), StatusCodes.Status404NotFound)]
        [InlineData("GET", typeof(UnauthorizedAccessException), StatusCodes.Status401Unauthorized)]
        public void GivenFail_WhenTypedResult_ExpectSpecificErrorCode(string requestMethod, Type exceptionType, int expectedCode)
        {
            var mapper = new GenericValueServiceStatusToApiResponseMapper(requestMethod);
            var exception = (Exception)Activator.CreateInstance(exceptionType)!;
            var result = mapper.Map(ServiceResult<object>.FailedResult(new []{ Error.FromException(exception) } ));
            Assert.Equal(expectedCode, result.StatusCode);
        }
        
        [Theory]
        [InlineData("GET")]
        public void GivenFail_WhenTypedResult_ExpectApiErrorType(string requestMethod)
        {
            var mapper = new GenericValueServiceStatusToApiResponseMapper(requestMethod);
            var result = mapper.Map(ServiceResult<object>.FailedResult(new Error[] { new Error("", "")  }));
            Assert.IsType<ApiErrorResponse>(result.Value);
        }
    }
}