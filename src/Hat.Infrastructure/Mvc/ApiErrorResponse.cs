using System.Collections.Generic;
using Hat.Infrastructure.Service;

namespace Hat.Infrastructure.Mvc
{
    public class ApiErrorResponse : ApiResponse
    {
        private readonly IEnumerable<Error> _errors;

        public ApiErrorResponse(IEnumerable<Error> errors)
        {
            _errors = errors;
        }
    }
}