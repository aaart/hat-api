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

        [HttpPut]
        public IActionResult UpdateState()
        {
            return NoContent();
        }

        [HttpPatch]
        public IActionResult ChangeState()
        {
            return Accepted();
        }
    }
}