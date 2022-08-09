using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;

namespace DigitalBookManagement.Services
{
    public class UserService : IUserService
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public UserService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }

        public IEnumerable<Book> SearchBook(UserSearchCriteria criteria)
        {
            var request = _digitalBookManagementContext.Books;

            if (!string.IsNullOrWhiteSpace(criteria.BookTitle))
                request.Where(x => x.BookTitle == criteria.BookTitle);

            if (!string.IsNullOrWhiteSpace(criteria.Publisher))
                request.Where(x => x.Publisher == criteria.Publisher);

            if (!string.IsNullOrWhiteSpace(criteria.Category))
                request.Where(x => x.Category == criteria.Category);

            if (criteria.Price != null)
                request.Where(x => x.Price == criteria.Price);

            if (!string.IsNullOrWhiteSpace(criteria.Category))
                request.Where(x => x.Category == criteria.Category);

            if (criteria.PublistDate != null)
                request.Where(x => x.PublistDate == criteria.PublistDate);

            return request;
        }
    }
}
