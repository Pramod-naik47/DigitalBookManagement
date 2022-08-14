using DigitalBookManagement.Model;

namespace DigitalBookManagement.Repositories
{
    public interface IAuthorService
    {
        string CreateBook(Book book);
        IEnumerable<Book> GetAllBooks(long userId);

        string AuthorLogin(User user);
        string EditBook(Book book);
        string LockOrUnlocBook(Book book);
    }
}