using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class NoValueServiceStatusToApiResponseMapperTest
    {
        [Theory]
        [InlineData("PUT", StatusCodes.Status204NoContent)]
        [InlineData("DELETE", StatusCodes.Status204NoContent)]
        public void GicenSuccess_WhenNotTypedResult_ExpectValidHttpResponse(string requestMethod, int expectedCode)
        {
            var mapper = new NoValueServiceStatusToApiResponseMapper(requestMethod);
            var result = mapper.Map(ServiceResult.SuccessResult());
            Assert.Equal(expectedCode, result.StatusCode);
        }
    }
}