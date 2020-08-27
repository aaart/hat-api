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
    }
}