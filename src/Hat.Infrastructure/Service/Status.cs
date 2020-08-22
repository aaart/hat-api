using System.Collections.Generic;

namespace Hat.Infrastructure.Service
{
    public class Status
    {
        private readonly List<string> _messages;
        
        private Status(string key)
        {
            Key = key;
            _messages = new List<string>();
        }
        
        public string Key { get; }
        public IEnumerable<string> Messages => _messages;
       
        public Status WithMessage(string message)
        {
            _messages.Add(message);
            return this;
        }

        public static Status Ok => New(PredefinedKey.OkKey).WithMessage("Operation completed successfully.");
        
        public static Status ResourceNotFound => New(PredefinedKey.ResourceNotFoundKey).WithMessage("The requested resource could not be found.");
        public static Status InvalidInput => New(PredefinedKey.InvalidInputKey).WithMessage("The given input is not valid.");
        public static Status UserAccessDenied => New(PredefinedKey.UserAccessDeniedKey).WithMessage("Current user can not access the requested resource.");
        
        public static Status New(string key)
        {
            return new Status(key);
        }
        
        public static bool IsOk(Status status) => status.Key == PredefinedKey.OkKey;
        
        public static class PredefinedKey
        {
            public const string OkKey = "EverythingIsOk";
            public const string ResourceNotFoundKey = "ResourceNotFound";
            public const string InvalidInputKey = "InvalidInput";
            public const string UserAccessDeniedKey = "UserAccessDenied";
        } 
    }
}