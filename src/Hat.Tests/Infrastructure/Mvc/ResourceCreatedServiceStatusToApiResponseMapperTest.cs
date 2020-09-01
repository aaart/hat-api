using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class ResourceCreatedServiceStatusToApiResponseMapperTest
    {
        [Theory]
        [InlineData("POST", StatusCodes.Status201Created)]
        public void GivenSuccess_WhenIdValid_ExpectValidHttpResponse(string requestMethod, int expectedCode)
        {
            var mapper = new ResourceCreatedServiceStatusToApiResponseMapper(requestMethod, "/");
            var result = mapper.Map(ResourceCreatedServiceResult<object>.SuccessResult(new object()));
            Assert.Equal(expectedCode, result.StatusCode);
        }

        [Fact]
        public void GivenResourceDirectory_WhenNewResourceCreated_ExpectLocationHeaderDefined()
        {
            const int newId = 1;
            const string resourceDirectory = "/resx";
            var mapper = new ResourceCreatedServiceStatusToApiResponseMapper("POST", resourceDirectory);
            var result = (CreatedResult)mapper.Map(ResourceCreatedServiceResult<int>.SuccessResult(newId));
            Assert.Equal($"{resourceDirectory}/{newId}", result.Location);
        } 
    }
}