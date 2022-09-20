using Author.Models;
using Author.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Author.Services
{
    public class AuthorService : IAuthorService
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public AuthorService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }

        /// <summary>
        /// This method is to create a book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>Result</returns>
        public async Task CreateBook(Book book)
        {
            _digitalBookManagementContext.Books.Add(book);
            await _digitalBookManagementContext.SaveChangesAsync();
        }

        /// <summary>
        /// This method will update the given book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>message whether the operation is scuccessfull or not</returns>
        public async Task<string> EditBook(Book book)
        {
            var result = _digitalBookManagementContext.Books.Where(x => x.BookId == book.BookId).FirstOrDefault();
            string message = string.Empty;
            if (result != null)
            {
                result.Publisher = book.Publisher;
                result.BookTitle = book.BookTitle;
                result.PublishDate = book.PublishDate;
                result.ModifiedDate = DateTime.Now;
                result.Category = book.Category;
                result.Content = book.Content;
                result.Active = book.Active;
                result.Logo = book.Logo;
                result.Price = book.Price;
                result.User = book.User;

                _digitalBookManagementContext.Books.Update(result);
                await _digitalBookManagementContext.SaveChangesAsync();
                message = "Book updated successfully";
            }
            else 
            {
                message = "Input provided is not valid";
            }
            return message;
        }

        public async Task DeleteBook(long bookId)
        {
            var book = _digitalBookManagementContext.Books.Where(b => b.BookId == bookId).FirstOrDefault();

            if (book != null)
            {
                _digitalBookManagementContext.Books.Remove(book);
                await _digitalBookManagementContext.SaveChangesAsync();
            }
        }
        public async Task<Book> GetBookById(long bookId)
        {
            var book = await _digitalBookManagementContext.Books.Where(b => b.BookId == bookId).ToListAsync();
            return book.FirstOrDefault();
        }

        public async Task<IEnumerable<VBook2User>> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher,long userId)
        {
            IEnumerable<VBook2User>? books = null;
            var request = await _digitalBookManagementContext.VBook2Users.Where(x => x.UserId == userId).ToListAsync();

            if (!string.IsNullOrWhiteSpace(bookTitle))
                books = request.Where(x => x.BookTitle == bookTitle);

            if (!string.IsNullOrWhiteSpace(publisher))
                books = request.Where(x => x.Publisher == publisher);

            if (!string.IsNullOrWhiteSpace(category))
                books = request.Where(x => x.Category == category);

            if (price != null && price != 0)
                books = request.Where(x => x.Price == price);

            if (!string.IsNullOrWhiteSpace(author))
                books = request.Where(x => x.UserName == author);

            if (books == null)
                books = request;

            return books.ToList();
        }
    }
}
