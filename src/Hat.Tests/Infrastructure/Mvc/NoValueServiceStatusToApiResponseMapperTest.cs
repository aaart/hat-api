using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class NoValueServiceStatusToApiResponseMapperTest
    {
        [Theory]
        [InlineData(Status.PredefinedKey.OkKey, "PUT", 204)]
        [InlineData(Status.PredefinedKey.OkKey, "DELETE", 204)]
        public void AllPredefinedReasons_WhenNoValueInServiceResult_ExpectValidHttpResponse(string key, string requestMethod, int expectedCode)
        {
            var mapper = new NoValueServiceStatusToApiResponseMapper(requestMethod);
            var result = mapper.Map(new ServiceResult(Status.New(key)));
            Assert.Equal(expectedCode, result.StatusCode);
        }
    }
}