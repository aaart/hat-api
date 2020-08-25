using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class GenericValueServiceStatusToApiResponseMapperTest
    {
        [Theory]
        [InlineData(Status.PredefinedKey.OkKey, "GET", StatusCodes.Status200OK)]
        public void AllPredefinedReasons_WhenValueInServiceResult_ExpectValidHttpResponse(string key, string requestMethod, int expectedCode)
        {
            var mapper = new GenericValueServiceStatusToApiResponseMapper(requestMethod);
            var result = mapper.Map(new ServiceResult<object>(Status.New(key)));
            Assert.Equal(expectedCode, result.StatusCode);
        }
    }
}