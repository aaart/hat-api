using Hat.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Services.Devices.Dto
{
    public class OnOffDeviceState : Dto<int>
    {
        [FromBody]
        public bool Enabled { get; set; }
    }
}