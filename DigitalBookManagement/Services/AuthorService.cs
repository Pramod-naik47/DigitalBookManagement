using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;

namespace DigitalBookManagement.Services
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
        public string CreateBook(Book book)
        {
            try
            {

                _digitalBookManagementContext.Books.Add(book);
                _digitalBookManagementContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Book save operation failed {ex.Message}";
            }
            return "Book saved suceessfully";
        }

        /// <summary>
        /// This method will get the all the books created by logged in author
        /// </summary>
        /// <returns>Book list</returns>
        public IEnumerable<Book> GetAllBooks(long userId)
        {
            var request = _digitalBookManagementContext.Books.Where(x => x.UserId == userId);
            return request;
        }

    }
}
