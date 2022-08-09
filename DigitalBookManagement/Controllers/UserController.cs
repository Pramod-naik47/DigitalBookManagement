using DigitalBookManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookManagement.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> SearchBooks([FromBody]Book book)
        {
            return Ok("User without authentication");
        }
    }
}
