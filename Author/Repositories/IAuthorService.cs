using Author.Models;

namespace Author.Repositories
{
    public interface IAuthorService
    {
        Task CreateBook(Book book);
        Task<string> EditBook(Book book);
        Task<string> LockOrUnlocBook(Book book);
        Task DeleteBook(long bookId);
        Task<Book> GetBookById(long bookId);
        Task<IEnumerable<VBook2User>> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher, long userId);
    }
}
