using DigitalBookManagement.Model;

namespace DigitalBookManagement.Repositories
{
    public interface IAuthorService
    {
        string CreateBook(Book book);
        IEnumerable<Book> GetAllBooks(long userId);

        string AuthorLogin(Author author);
        string EditBook(Book book);
        string LockOrUnlocBook(Book book);
    }
}