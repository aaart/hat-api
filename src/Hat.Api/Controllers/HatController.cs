using System;
using Microsoft.AspNetCore.Mvc;

namespace Hat.Api.Controllers
{
    public class HatController : Controller
    {
        // GET
        public IActionResult ApiStatus()
        {
            return Ok($"Hi! API is active. timestamp: {DateTime.Now}");
        }
    }
}