using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Services.Devices.Dto
{
    public class OnOffDeviceState : Dto<int>
    {
        public bool Enabled { get; set; }
        
        public string Title { get; set; }
    }
}