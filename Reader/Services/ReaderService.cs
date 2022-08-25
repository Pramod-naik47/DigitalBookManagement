using Reader.Models;
using Reader.Repsitories;

namespace Reader.Services
{
    public class ReaderService : IReaderService
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public ReaderService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }

        public IEnumerable<Book> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher)
        {
            IEnumerable<Book>? books = null;
            var request = _digitalBookManagementContext.Books.Where(b => b.Active == true);

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

            if (books == null)
                books = request;

            return books.ToList();
        }

        /// <summary>
        /// Purchases the book.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public void PurchaseBook(Payment payment)
        {
            if (payment != null)
            {
                _digitalBookManagementContext.Payments.Add(payment);
                _digitalBookManagementContext.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns>Books requested by user</returns>
        public Book GetBookById(long bookId)
        {
            var book = _digitalBookManagementContext.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            return book;
        }

        /// <summary>
        /// Gets the payment history.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>all payment history of the user</returns>
        public IEnumerable<VBookPayment> GetPaymentHistory(string email)
        {
            var books = _digitalBookManagementContext.VBookPayments.Where(b => b.Email == email);
            return books;
        }

        public VBookPayment GetBookByIdForPayment(long bookId)
        {
            
            var book = _digitalBookManagementContext.VBookPayments.Where(b => b.BookId == bookId).FirstOrDefault();
            return book;
        }
    }
}
