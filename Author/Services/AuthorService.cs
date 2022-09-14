using Author.Models;
using Author.Repositories;

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
        public void CreateBook(Book book)
        {
            _digitalBookManagementContext.Books.Add(book);
            _digitalBookManagementContext.SaveChanges();
        }

        /// <summary>
        /// This method will take user name and password validate the user
        /// </summary>
        /// <param name="author"></param>
        /// <returns>return a message whether the login is scuccessfull or not</returns>
        public string AuthorLogin(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password))
            {
                string message = string.Empty;
                var result = _digitalBookManagementContext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

                if (result != null)
                    message = $"Author {user.UserName} logged in successfully";
                else
                    message = "Invalid user name or password";

                return message;
            }
            return $"Please provide valid input";
        }

        /// <summary>
        /// This method will update the given book
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>message whether the operation is scuccessfull or not</returns>
        public string EditBook(Book book)
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
                _digitalBookManagementContext.SaveChanges();
                message = "Book updated successfully";
            }
            else 
            {
                message = "Input provided is not valid";
            }
            return message;
        }
        /// <summary>
        /// This method will lock or unlock the book
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>return a message whether the book is locked or unlocked</returns>
        public string LockOrUnlocBook(Book book)
        {
            try
            {
                var result = _digitalBookManagementContext.Books.Where(x => x.BookId == book.BookId).FirstOrDefault();

                if (result != null)
                {
                    result.Active = book.Active;
                    result.ModifiedDate = DateTime.Now;

                    _digitalBookManagementContext.Books.Update(result);
                    _digitalBookManagementContext.SaveChanges();
                    string message = result.Active == true ? $"Book {result.BookTitle}unlocked successfully" : $"Book {result.BookTitle} locked successfully";

                    return message;
                }
                return $"Input provided is not valid";
            }
            catch (Exception ex)
            {
                return $"Operation operation faild : {ex.Message}";
            }
        }

        public void DeleteBook(long bookId)
        {
            var book = _digitalBookManagementContext.Books.Where(b => b.BookId == bookId).FirstOrDefault();

            if (book != null)
            {
                _digitalBookManagementContext.Books.Remove(book);
                _digitalBookManagementContext.SaveChanges();
            }
        }
        public Book GetBookById(long bookId)
        {
            var book = _digitalBookManagementContext.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            return book;
        }

        public IEnumerable<VBook2User> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher,long userId)
        {
            IEnumerable<VBook2User>? books = null;
            var request = _digitalBookManagementContext.VBook2Users.Where(x => x.UserId == userId);


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
