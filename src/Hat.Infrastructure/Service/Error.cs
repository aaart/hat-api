using System;
using System.IO;

namespace Hat.Infrastructure.Service
{
    public class Error
    {
        
        private const string NotFound = "FileNotFound";
        private const string Unauthorized = "UnauthorizedAccess";
        
        public static bool IsNotFound(Error error) => error.Type == NotFound;
        public static bool IsUnauthorized(Error error) => error.Type == Unauthorized;

        public static Error FromException(Exception exception) => new Error(exception.GetType().Name.Replace("Exception", String.Empty), exception.Message);
        
        public Error(string type, string message)
        {
            Type = type;
            Message = message;
        }

        public string Type { get; }
        public string Message { get; }
    }
}