using System;
using System.Collections;
using System.Collections.Generic;
using Hat.Infrastructure.Mvc;
using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Hat.Tests.Infrastructure.Mvc
{
    public class ErrorToResponseMapperTest
    {
        [Theory]
        [ClassData(typeof(PredefinedErrorsData))]
        public void GivenErrorMapper_ExpectValidStatusCode(Error error, int expectedCode)
        {
            var mapper = new ErrorToResponseMapper();
            var result = mapper.Map(new[] {error});
            Assert.Equal(expectedCode, result.StatusCode);
        }
        
        private class PredefinedErrorsData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { Error.Unauthorized(""), StatusCodes.Status401Unauthorized };
                yield return new object[] { Error.NotFound(""), StatusCodes.Status404NotFound };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}