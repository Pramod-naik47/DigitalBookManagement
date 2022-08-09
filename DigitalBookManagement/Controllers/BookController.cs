using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public ActionResult<string> CreateBook([FromBody]Book book)
        {
            string result = _bookService.CreateBook(book);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<string> GetBooks()
        {
            string result = "Book1, Book2";
            return Ok(result);
        }
    }
}
