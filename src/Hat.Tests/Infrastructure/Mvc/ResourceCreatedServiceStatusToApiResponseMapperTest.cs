using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class ResourceCreatedServiceStatusToApiResponseMapperTest
    {
        [Theory]
        [InlineData(Status.PredefinedKey.OkKey, "POST", 201)]
        public void AllPredefinedReasons_WhenResourceIdInServiceResult_ExpectValidHttpResponse(string key, string requestMethod, int expectedCode)
        {
            var mapper = new ResourceCreatedServiceStatusToApiResponseMapper(requestMethod, "/");
            var result = mapper.Map(new ResourceCreatedServiceResult<object>(Status.New(key)));
            Assert.Equal(expectedCode, result.StatusCode);
        }

        [Fact]
        public void ResourceDirectory_WhenCreatingNewResource_ExpectLocationHeaderDefined()
        {
            const int newId = 1;
            const string resourceDirectory = "/resx";
            var mapper = new ResourceCreatedServiceStatusToApiResponseMapper("POST", resourceDirectory);
            var result = mapper.Map(new ResourceCreatedServiceResult<int>(newId));
            Assert.Equal($"{resourceDirectory}/{newId}", result.Location);
        } 
    }
}