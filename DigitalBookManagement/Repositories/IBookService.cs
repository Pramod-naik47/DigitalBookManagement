using DigitalBookManagement.Model;

namespace DigitalBookManagement.Repositories
{
    public interface IBookService
    {
        string CreateBook(Book book);
    }
}