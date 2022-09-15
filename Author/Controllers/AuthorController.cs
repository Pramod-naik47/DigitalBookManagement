﻿using Author.ApplicationEnums;
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

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            string result = string.Empty;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity != null)
                {
                    AppAuthorizationClaims claim = new AppAuthorizationClaims(identity);

                    if (claim.UserType == "Author")
                    {
                        if (!string.IsNullOrWhiteSpace(claim.UserId))
                            book.UserId = Convert.ToUInt32(claim.UserId);

                         await _authorService.CreateBook(book);
                        result = "Book created sucessfully";
                    }
                    else
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result.ToList());
        }

        /// <summary>
        /// Edits the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        [HttpPut("EditBook")]
        public async Task<IActionResult> EditBook([FromBody] Book book)
        {
            string result = string.Empty;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity != null)
                {
                    AppAuthorizationClaims claim = new AppAuthorizationClaims(identity);
                    if (claim.UserType == "Author")
                    {
                        await _authorService.EditBook(book);
                        result = "Book Edit sucessfull";
                    }
                }
                else
                {
                    BadRequest();
                }      
            }
            catch (Exception ex)
            {
                result = $"Operation failed {ex.Message}";
            }

            return Ok(result.ToList());
        }

        /// <summary>
        /// Locks the or unloc book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        [HttpPut("LockOrUnlockBook")]
        public async Task<IActionResult> LockOrUnlocBook([FromBody] Book book)
        {
            string result = await _authorService.LockOrUnlocBook(book);
            return Ok(result.ToList());
        }

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(long bookId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string result = string.Empty;
            try
            {
                if (identity != null)
                {
                    AppAuthorizationClaims claim = new AppAuthorizationClaims(identity);

                    if (claim.UserType == "Author")
                    {
                        if (bookId != 0)
                        {
                            await _authorService.DeleteBook(bookId);
                            result = "Book deleted sucessfully";
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                result = $"Delete failed {ex.Message}";
            }
            return Ok(result.ToList());
        }

        
        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(string bookId)
        {
            string result = string.Empty;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity != null)
                {
                    AppAuthorizationClaims claim = new AppAuthorizationClaims(identity);

                    if (claim.UserType == "Author")
                    {
                        Book book = await _authorService.GetBookById(Convert.ToInt32(bookId));
                        if (book != null)
                            return Ok(book);
                        else
                            return NoContent();
                    } 
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Ok(result.ToList());
        }

        /// <summary>
        /// Search the book by prvided input
        /// </summary>
        /// <param name="bookTitle">The book title.</param>
        /// <param name="category">The category.</param>
        /// <param name="author">The author.</param>
        /// <param name="price">The price.</param>
        /// <param name="publisher">The publisher.</param>
        /// <returns>List of books if any search criteria meets</returns>
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> SearchBooks(string? bookTitle, string? category, string? author, decimal? price, string? publisher)
        {
            string message = string.Empty;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            try
            {
                if (identity != null)
                {
                    AppAuthorizationClaims claim = new AppAuthorizationClaims(identity);

                    if (claim.UserType == UserType.Author.ToString() && !string.IsNullOrWhiteSpace(claim.UserId))
                    {
                        var result = await _authorService.SearchBook(bookTitle, category, author, price, publisher,Convert.ToInt64(claim.UserId));
                        if (result.Count() > 0)
                            return Ok(result.ToList());
                        else
                            return NoContent();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Ok(message.ToList());
        }
    }
}
