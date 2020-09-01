using System;
using System.Collections.Generic;
using Hat.Infrastructure.Mvc;
using Hat.Services.Common.Dto;
using Hat.Services.Devices;
using Hat.Services.Devices.Dto;
using Hat.Services.Devices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Api.Controllers
{
    /// <summary>
    /// Defines actions that can be executed on On/Off devices.
    /// </summary>
    [Route("devices/[controller]")]
    public class OnOffController : ApiController
    {
        private readonly IGetDevicesService _getDevicesService;
        private readonly IGetDeviceDetailsService _getDeviceDetailsService;

        public OnOffController(IGetDevicesService getDevicesService,
            IGetDeviceDetailsService getDeviceDetailsService)
        {
            _getDevicesService = getDevicesService;
            _getDeviceDetailsService = getDeviceDetailsService;
        }
        
        /// <summary>
        /// Gets a list of on/off devices registered in the system.
        /// </summary>
        /// <returns>The list of devices.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<DeviceDescription>>), StatusCodes.Status200OK)]
        public IActionResult All([FromQuery]PagingRequest pagingRequest) => 
            CreateResponse(_getDevicesService.Execute(pagingRequest));

        /// <summary>
        /// Gets details of the given device.
        /// </summary>
        /// <param name="request">Object request</param>
        /// <returns>Device details.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<DeviceDetails>), StatusCodes.Status200OK)]
        public IActionResult Details([FromRoute]ObjectRequest request) =>
            CreateResponse(_getDeviceDetailsService.Execute(request));
        
        /// <summary>
        /// Registers new state of a given device and starts all actions required to physically change the original state.
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <returns>New state object.</returns>
        [HttpPost("{deviceId}/states")]
        public IActionResult ProcessNewState([FromBody]int deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the most recent state for the given device.
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <returns>State result.</returns>
        [HttpGet("{deviceId}/states/last")]
        [Produces(typeof(ApiResponse<DeviceDetails>))]
        public IActionResult GetLastState(int deviceId)
        {
            return Ok();
        }
        
        /// <summary>
        /// Triggers async update of the the most recent state without triggering any actions that physically change the state of a given device. 
        /// </summary>
        /// <param name="deviceId">Device id.</param>
        /// <returns>Identifier referencing the task that process the update of the given state.</returns>
        [HttpPut("{deviceId}/states/last")]
        public IActionResult UpdateLastState([FromBody]int deviceId)
        {
            return Created(HttpContext.Request.Path.Value + "/100", 100);
        }
    }
}