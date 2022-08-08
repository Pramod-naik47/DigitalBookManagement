using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<string> CreateUser([FromBody]UserDetail userDetails)
        {
            string result = _userService.CreateUser(userDetails);
            return Ok(result);
        }
    }
}