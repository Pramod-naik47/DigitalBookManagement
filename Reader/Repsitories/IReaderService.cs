using Reader.Models;

namespace Reader.Repsitories
{
    public interface IReaderService
    {
        Task<IEnumerable<VBook2User>> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher);
        void PurchaseBook(Payment payment);
        Task<Book> GetBookById(long bookId);
        Task<IEnumerable<VBookPayment>> GetPaymentHistory(long userId);
        Task<VBookPayment> GetBookByIdForPayment(long bookId);

        Task GetRefund(long paymentId);

    }
}
