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

        /// <summary>
        /// This method will take user name and password validate the user
        /// </summary>
        /// <param name="author"></param>
        /// <returns>return a message whether the login is scuccessfull or not</returns>
        public string AuthorLogin(Author author)
        {
            string message = string.Empty;
            var result = _digitalBookManagementContext.Author.Where(x => x.UserName == author.UserName && x.Password == author.Password).FirstOrDefault();

            if (result != null)
                message = $"Author {author.UserName} logged in successfully";
            else
                message = "Invalid user name or password";

            return message;
        }

    }
}
