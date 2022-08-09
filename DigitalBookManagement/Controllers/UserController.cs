using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookManagement.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("SearchForBook")]
        public IEnumerable<Book> SearchBooks([FromBody]UserSearchCriteria book)
        {
            var result = _userService.SearchBook(book);
            return result.ToList();
        }
    }
}
