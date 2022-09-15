using Reader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderApiTestCase.MockData
{
    public class PaymentMockData
    {
        public static IEnumerable<VBookPayment> GetPaymentHistory()
        {
            return new List<VBookPayment>
            {
                new VBookPayment
                {
                   BookId = 1,
                   BookTitle = "Unit test",
                   Category = "Unit test",
                   Price = 100,
                   Content = "This is for unit testing",
                   Active = true,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   PublishDate = DateTime.Now,
                   Publisher = "XUnit",
                   UserId = 1,
                   PaymentId = 1,
                   PaymentDate = DateTime.Now,
                   Email = "xunit@gmail.com",
                   UserName = "xUnit",
                   PhoneNumber = 9876567876
                },
                new VBookPayment
                {
                   BookId = 2,
                   BookTitle = "Unit test2",
                   Category = "Unit test",
                   Price = 1000,
                   Content = "This is for unit testing2",
                   Active = true,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   PublishDate = DateTime.Now,
                   Publisher = "XUnit",
                   UserId = 1,
                   PaymentId = 2,
                   PaymentDate = DateTime.Now,
                   Email = "xunit@gmail.com",
                   UserName = "xUnit",
                   PhoneNumber = 8787545423
                }
            };
        }

        public static List<VBookPayment> EmptyPaymentHistory()
        {
            return new List<VBookPayment>();
        }

        public static VBookPayment GetBook()
        {
            return new VBookPayment
            {
                BookId = 2,
                BookTitle = "Unit test2",
                Category = "Unit test",
                Price = 1000,
                Content = "This is for unit testing2",
                Active = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                PublishDate = DateTime.Now,
                Publisher = "XUnit",
                UserId = 1,
                PaymentId = 2,
                PaymentDate = DateTime.Now,
                Email = "xunit@gmail.com",
                UserName = "xUnit",
                PhoneNumber = 8787545423
            };
        }

        public static VBookPayment GetEmptyBook()
        {
            return null;
        }
    }
}
