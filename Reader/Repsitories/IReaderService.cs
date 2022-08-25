using Reader.Models;

namespace Reader.Repsitories
{
    public interface IReaderService
    {
        IEnumerable<Book> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher);
        void PurchaseBook(Payment payment);
        Book GetBookById(long bookId);
        IEnumerable<VBookPayment> GetPaymentHistory(string email);
        VBookPayment GetBookByIdForPayment(long bookId);

    }
}
