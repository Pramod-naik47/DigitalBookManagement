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

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(string bookId)
        {
            string result = string.Empty;
            try
            {
                Book book = _readerService.GetBookById(Convert.ToInt32(bookId));
                if (book != null)
                    return Ok(book);
                else
                    result = "Book not found";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Ok(result.ToList());
        }

        [HttpGet("GetPaymentHistory")]
        public IActionResult GetPaymentHistory(string email)
        {
            string result = string.Empty;
            try
            {
                var payment =  _readerService.GetPaymentHistory(email);
                return Ok(payment.ToList());
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return Ok(result.ToList());
        }
    }
}
