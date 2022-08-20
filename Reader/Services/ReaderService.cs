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

        public IEnumerable<Book> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher)
        {
            IEnumerable<Book> books = new List<Book>();
            var request = _readerlBookManagementContext.Books;

            if (!string.IsNullOrWhiteSpace(bookTitle))
                books = request.Where(x => x.BookTitle == bookTitle);

            if (!string.IsNullOrWhiteSpace(publisher))
                books = request.Where(x => x.Publisher == publisher);

            if (!string.IsNullOrWhiteSpace(category))
                books = request.Where(x => x.Category == category);

            if (price != null && price != 0)
                books = request.Where(x => x.Price == price);

            //if (criteria.PublistDate != null)
            //    books = request.Where(x => x.PublishDate == criteria.PublistDate);

            //if (criteria.UserId != null)
            //    books = request.Where(x => x.UserId == criteria.UserId);

            return books.ToList();
        }
    }
}
