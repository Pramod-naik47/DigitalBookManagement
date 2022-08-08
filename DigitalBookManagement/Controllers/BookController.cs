using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController :ControllerBase
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
    }
}
