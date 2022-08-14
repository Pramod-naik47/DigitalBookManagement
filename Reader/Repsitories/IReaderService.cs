using Reader.Models;

namespace Reader.Repsitories
{
    public interface IReaderService
    {
        IEnumerable<Book> SearchBook(ReaderSearchCriteria searchCriteria);
    }
}
