
using Microsoft.AspNetCore.Mvc;

namespace inventorymanagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   

    public class BaseController : ControllerBase
    {
        protected IActionResult SuccessResponse(object data, string message = "Success")
        {
            var response = new
            {
                status = true,
                message = message,
                data = data
            };

            return Ok(response);
        }

        protected IActionResult ErrorResponse(string message)
        {
            var response = new
            {
                status = false,
                message = message,
                data = ""
            };

            return BadRequest(response);
        }

        protected IActionResult NotFoundResponse(string msg)
        {
            var response = new
            {
                status = false,
                message = msg,
                data = ""
            };

            return NotFound(response);
        }
    }
}