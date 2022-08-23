using Author.Models;

namespace Author.Repositories
{
    public interface IAuthorService
    {
        string CreateBook(Book book);
        IEnumerable<Book> GetAllBooks(long userId);
        string AuthorLogin(User user);
        string EditBook(Book book);
        string LockOrUnlocBook(Book book);
        void DeleteBook(long bookId);
        Book GetBookById(long bookId);
    }
}
