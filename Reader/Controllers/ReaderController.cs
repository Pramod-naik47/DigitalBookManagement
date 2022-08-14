using Microsoft.AspNetCore.Mvc;
using Reader.Models;
using Reader.Repsitories;

namespace Reader.Controllers
{
    [ApiController]
    [Route("api/Reader")]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderService _readerService;
        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet("SearchForBook")]
        public IEnumerable<Book> SearchBooks([FromBody] ReaderSearchCriteria book)
        {
            var result = _readerService.SearchBook(book);
            return result.ToList();
        }
    }
}
