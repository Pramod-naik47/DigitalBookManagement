using Reader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderApiTestCase.MockData
{
    public static class BookMockData
    {
        public static Book GetBook()
        {
            return new Book
            {
                BookId = 1,
                Active = true,
                BookTitle = "Unit test",
                Category = "Test",
                Content = "XUnit test is mandatory for web api",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Price = 200
            };
        }

        public static Book GetEmptyBook()
        {
            return null;
        }
    }
}
