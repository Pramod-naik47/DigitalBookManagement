﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Search the book by prvided input
        /// </summary>
        /// <param name="bookTitle">The book title.</param>
        /// <param name="category">The category.</param>
        /// <param name="author">The author.</param>
        /// <param name="price">The price.</param>
        /// <param name="publisher">The publisher.</param>
        /// <returns>List of books if any seach criteria meets</returns>
        [HttpGet("SearchForBook")]
        public IActionResult SearchBooks(string? bookTitle, string? category, string? author, decimal? price, string? publisher)
        {
            var result = _readerService.SearchBook(bookTitle, category, author, price, publisher);
            return Ok(result.ToList());
        }

        /// <summary>
        /// Take the payment object as parameter and save into db
        /// </summary>
        /// <param name="payment">Payment object</param>
        /// <returns>Message</returns>
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

        /// <summary>
        /// Gets the book by id.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns>Book</returns>
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

        /// <summary>
        /// Gets the payment history.
        /// </summary>
        /// <param name="email">The email provided by the user.</param>
        /// <returns>Hostory of payment by the user</returns>
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
        /// <summary>
        /// Gets the book by book id
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns>Book</returns>
        [HttpGet("GetBookByIdForPayment")]
        public IActionResult GetBookByIdForPayment(string bookId)
        {
            string result = string.Empty;
            try
            {
                VBookPayment book = _readerService.GetBookByIdForPayment(Convert.ToInt32(bookId));
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
    }
}
