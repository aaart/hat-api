using System;
using Hat.Infrastructure.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Api.Controllers
{
    public class HatController : ApiController
    {
        [HttpGet]
        public IActionResult ApiStatus()
        {
            return Ok($"Hi! API is active. timestamp: {DateTime.Now}");
        }
    }
}