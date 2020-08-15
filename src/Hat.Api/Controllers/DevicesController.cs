using Microsoft.AspNetCore.Mvc;

namespace Hat.Api.Controllers
{
    public class DevicesController : Controller
    {
        [HttpGet]
        public IActionResult All()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Status()
        {
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Enable()
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Disable()
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult MarkEnabled()
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult MarkDisabled()
        {
            return NoContent();
        }
    }
}