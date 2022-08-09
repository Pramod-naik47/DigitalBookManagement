using DigitalBookManagement.Model;

namespace DigitalBookManagement.Repositories
{
    public interface IUserService
    {
        IEnumerable<Book> SearchBook(UserSearchCriteria searchCriteria);
    }
}