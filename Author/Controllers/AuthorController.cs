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
        public IActionResult CreateBook([FromBody] Book book)
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

                        _authorService.CreateBook(book);
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
        /// Gets all book.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBooks")]
        public IEnumerable<Book> GetAllBook()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            
            if (identity != null)
            {
                AppAuthorizationClaims claim = new AppAuthorizationClaims(identity);

                if (!string.IsNullOrWhiteSpace(claim.UserId))
                    return  _authorService.GetAllBooks(Convert.ToInt64(claim.UserId));
            }
            return null;
        }

        [HttpPost("AuthorLogin")]
        public ActionResult<string> AuthorLogin([FromBody]User author)
        {
            string result = _authorService.AuthorLogin(author);
            return Ok(result);
        }

        /// <summary>
        /// Edits the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        [HttpPut("EditBook")]
        public IActionResult EditBook([FromBody] Book book)
        {
            string result = string.Empty;
            try
            {
                result = _authorService.EditBook(book);
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
        [HttpPut("LockOrUnlocBook")]
        public ActionResult<string> LockOrUnlocBook([FromBody] Book book)
        {
            string result = _authorService.LockOrUnlocBook(book);
            return result;
        }

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpPost("DeleteBook")]
        public IActionResult DeleteBook(Book book)
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
                        if (book.BookId != 0 )
                        {
                            _authorService.DeleteBook(book.BookId);
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
        public IActionResult GetBookById(string bookId)
        {
            string result = string.Empty;
            try
            {
                Book book = _authorService.GetBookById(Convert.ToInt32(bookId));
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
