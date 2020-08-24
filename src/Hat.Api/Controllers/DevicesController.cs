using System.Collections;
using System.Collections.Generic;
using Hat.Infrastructure.Mvc;
using Hat.Services.Devices;
using Hat.Services.Devices.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Api.Controllers
{
    [Route("[controller]")]
    public class DevicesController : ApiController
    {
        private readonly IGetDevicesService _getDevicesService;

        public DevicesController(IGetDevicesService getDevicesService)
        {
            _getDevicesService = getDevicesService;
        }
        
        [HttpGet]
        [Route("/")]
        [Produces(typeof(IEnumerable<DeviceDescription>))]
        public IActionResult All()
        {
            return CreateResponse(_getDevicesService.Execute());
        }

        [HttpGet]
        [Route("/{deviceId}/status")]
        public IActionResult Status(int deviceId)
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("/{deviceId}/enable")]
        public IActionResult Enable(int deviceId)
        {
            return NoContent();
        }

        [HttpPost]
        [Route("/{deviceId}/disable")]
        public IActionResult Disable(int deviceId)
        {
            return NoContent();
        }

        [HttpPost]
        [Route("/{deviceId}/markenabled")]
        public IActionResult MarkEnabled(int deviceId)
        {
            return NoContent();
        }

        [HttpPost]
        [Route("/{deviceId}/markdisabled")]
        public IActionResult MarkDisabled(int deviceId)
        {
            return NoContent();
        }
    }
}