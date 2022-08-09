using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;
using DigitalBookManagement.SharedResource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookManagement.Controllers
{
    [ApiController]
    [Route("api/Author")]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("CreateBook")]
        public ActionResult<string> CreateBook([FromBody]Book book)
        {
            string result = _authorService.CreateBook(book);
            return Ok(result);
        }
        [HttpGet("GetAllBooks")]
        public IEnumerable<Book> GetAllBook([FromBody]CommonResource commonResource)
        {
            var result = _authorService.GetAllBooks(commonResource.UserId);
            return result;
        }
    }
}
