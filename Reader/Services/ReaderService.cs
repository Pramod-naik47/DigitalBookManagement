using Microsoft.EntityFrameworkCore;
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

        public async  Task<IEnumerable<VBook2User>> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher)
        {
            IEnumerable<VBook2User>? books = null;
            var request = await _digitalBookManagementContext.VBook2Users.Where(b => b.Active == true).ToListAsync();

            if (!string.IsNullOrWhiteSpace(bookTitle))
                books = request.Where(x => x.BookTitle == bookTitle);

            if (!string.IsNullOrWhiteSpace(publisher))
                books = request.Where(x => x.Publisher == publisher);

            if (!string.IsNullOrWhiteSpace(category))
                books = request.Where(x => x.Category == category);

            if (price != null && price != 0)
                books = request.Where(x => x.Price == price);

            if (!string.IsNullOrWhiteSpace(author))
                books = request.Where(x => x.UserName == author);

            if (books == null)
                books = request;

            return  books;
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
        public async Task<Book> GetBookById(long bookId)
        {
            var book = await _digitalBookManagementContext.Books.Where(b => b.BookId == bookId).ToListAsync();
            return book.FirstOrDefault();
        }

        /// <summary>
        /// Gets the payment history.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>all payment history of the user</returns>
        public async Task<IEnumerable<VBookPayment>> GetPaymentHistory(long userId)
        {
            var books = await _digitalBookManagementContext.VBookPayments.Where(b => b.UserId == userId).ToListAsync();
            return books;
        }

        public async Task<VBookPayment> GetBookByIdForPayment(long bookId)
        {
            
            var book = await _digitalBookManagementContext.VBookPayments.Where(b => b.BookId == bookId).ToListAsync();
            return book.FirstOrDefault();
        }

        /// <summary>
        /// Take the payment Id as parameter and find the record and delete the record of payment.
        /// </summary>
        /// <param name="paymentId">The paymentId.</param>
        public async Task GetRefund(long paymentId)
        {
            var payment = _digitalBookManagementContext.Payments.Where(b => b.PaymentId == paymentId).FirstOrDefault();

            if (payment != null)
            {
                _digitalBookManagementContext.Payments.Remove(payment);
                await _digitalBookManagementContext.SaveChangesAsync();
            }
        }
    }
}
