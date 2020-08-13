using Microsoft.AspNetCore.Mvc;

namespace Hat.Api.Controllers
{
    public class DevicesController : Controller
    {
        public IActionResult All()
        {
            return Ok();
        }

        public IActionResult UpdateState()
        {
            return NoContent();
        }

        public IActionResult ChangeState()
        {
            return Accepted();
        }
    }
}