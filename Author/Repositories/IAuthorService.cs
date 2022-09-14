using Author.Models;

namespace Author.Repositories
{
    public interface IAuthorService
    {
        void CreateBook(Book book);
        string AuthorLogin(User user);
        string EditBook(Book book);
        string LockOrUnlocBook(Book book);
        void DeleteBook(long bookId);
        Book GetBookById(long bookId);
        IEnumerable<VBook2User> SearchBook(string? bookTitle, string? category, string? author, decimal? price, string? publisher, long userId);
    }
}
