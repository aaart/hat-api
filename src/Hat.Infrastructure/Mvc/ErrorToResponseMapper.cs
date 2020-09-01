using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Infrastructure.Mvc
{
    public class ErrorToResponseMapper
    {
        public ObjectResult Map(Error[] errors)
        {
            var majorError = errors[0];
            var errorResponse = new ApiErrorResponse(errors);
            if (Error.IsNotFound(majorError))
            {
                return new NotFoundObjectResult(errorResponse);
            }
            if (Error.IsUnauthorized(majorError))
            {
                return new UnauthorizedObjectResult(errorResponse);
            }
            
            return new ObjectResult(errorResponse) { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}