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
            IEnumerable<Book> books = new List<Book>();
            var request = _digitalBookManagementContext.Books;

            if (!string.IsNullOrWhiteSpace(criteria.BookTitle))
                books =  request.Where(x => x.BookTitle == criteria.BookTitle);

            if (!string.IsNullOrWhiteSpace(criteria.Publisher))
                books = request.Where(x => x.Publisher == criteria.Publisher);

            if (!string.IsNullOrWhiteSpace(criteria.Category))
                books = request.Where(x => x.Category == criteria.Category);

            if (criteria.Price != null)
                books = request.Where(x => x.Price == criteria.Price);

            if (!string.IsNullOrWhiteSpace(criteria.Category))
                books = request.Where(x => x.Category == criteria.Category);

            if (criteria.PublistDate != null)
                books = request.Where(x => x.PublishDate == criteria.PublistDate);

            if (criteria.UserId != null)
                books = request.Where(x => x.UserId == criteria.UserId); 

            return books;
        }
    }
}
