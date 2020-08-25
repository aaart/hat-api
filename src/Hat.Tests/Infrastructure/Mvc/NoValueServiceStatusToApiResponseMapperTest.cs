using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class NoValueServiceStatusToApiResponseMapperTest
    {
        [Theory]
        [InlineData(Status.PredefinedKey.OkKey, "PUT", StatusCodes.Status204NoContent)]
        [InlineData(Status.PredefinedKey.OkKey, "DELETE", StatusCodes.Status204NoContent)]
        public void AllPredefinedReasons_WhenNoValueInServiceResult_ExpectValidHttpResponse(string key, string requestMethod, int expectedCode)
        {
            var mapper = new NoValueServiceStatusToApiResponseMapper(requestMethod);
            var result = mapper.Map(new ServiceResult(Status.New(key)));
            Assert.Equal(expectedCode, result.StatusCode);
        }
    }
}