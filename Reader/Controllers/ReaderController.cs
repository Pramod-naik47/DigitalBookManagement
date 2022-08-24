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
        public IActionResult SearchBooks(string? bookTitle, string? category, string? author, decimal? price, string? publisher)
        {
            var result = _readerService.SearchBook(bookTitle, category, author, price, publisher);
            return Ok(result.ToList());
        }

        [HttpPost("PurchaseBook")]
        public IActionResult PurchaseBook([FromBody] Payment payment)
        {
            string result = string.Empty;
            try
            {
                _readerService.PurchaseBook(payment);
                result = "Payment sucessfull";
            } 
            catch(Exception ex)
            {
                result = ex.Message;
            }
            return Ok(result.ToList());
        }


    }
}
