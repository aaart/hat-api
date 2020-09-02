using System;
using System.IO;

namespace Hat.Infrastructure.Service
{
    public class Error
    {
        
        
        
        public static Error NotFound(string message) => new Error(PredefinedErrors.NotFound, message);
        public static Error Unauthorized(string message) => new Error(PredefinedErrors.UnAuthorized, message);
        
        public static bool IsNotFound(Error error) => error.Type == PredefinedErrors.NotFound;
        public static bool IsUnauthorized(Error error) => error.Type == PredefinedErrors.UnAuthorized;

        public static Error FromException(Exception exception) => new Error(exception.GetType().Name.Replace("Exception", String.Empty), exception.Message);
        
        public Error(string type, string message)
        {
            Type = type;
            Message = message;
        }

        public string Type { get; }
        public string Message { get; }
        
        private static class PredefinedErrors
        {
            public const string NotFound = "FileNotFound";
            public const string UnAuthorized = "UnauthorizedAccess";
        }
    }
}