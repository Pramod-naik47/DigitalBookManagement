using Author.CommonResources;
using Author.Models;
using Author.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Author.Controllers
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
        public ActionResult<string> CreateBook([FromBody] Book book)
        {
            string result = string.Empty;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            
            if (identity != null)
            {
                AppAuthorizationClaims claim = new AppAuthorizationClaims(identity);
                if (claim.UserType == "Author")
                    result = _authorService.CreateBook(book);
                else
                    result = "User is not valid";
            }
            return Ok(result);
        }

        [HttpGet("GetAllBooks")]
        public IEnumerable<Book> GetAllBook([FromBody]CommonResource commonResource)
        {
            var result = _authorService.GetAllBooks(commonResource.UserId);
            return result;
        }

        [HttpPost("AuthorLogin")]
        public ActionResult<string> AuthorLogin([FromBody]User author)
        {
            string result = _authorService.AuthorLogin(author);
            return Ok(result);
        }

        [HttpPut("EditBook")]
        public ActionResult<string> EditBook([FromBody] Book book)
        {
            string result = _authorService.EditBook(book);
            return result;
        }

        [HttpPut("LockOrUnlocBook")]
        public ActionResult<string> LockOrUnlocBook([FromBody] Book book)
        {
            string result = _authorService.LockOrUnlocBook(book);
            return result;
        }
    }
}
