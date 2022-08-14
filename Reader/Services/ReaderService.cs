using Reader.Models;
using Reader.Repsitories;

namespace Reader.Services
{
    public class ReaderService : IReaderService
    {
        public ReaderBookManagementContext _readerlBookManagementContext { get; set; }
        public ReaderService(ReaderBookManagementContext readerBookManagementContext)
        {
            _readerlBookManagementContext = readerBookManagementContext;
        }

        public IEnumerable<Book> SearchBook(ReaderSearchCriteria criteria)
        {
            IEnumerable<Book> books = new List<Book>();
            var request = _readerlBookManagementContext.Books;

            if (!string.IsNullOrWhiteSpace(criteria.BookTitle))
                books = request.Where(x => x.BookTitle == criteria.BookTitle);

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
