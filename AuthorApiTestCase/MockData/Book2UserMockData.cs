using Author.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorApiTestCase.MockData
{
    public static class Book2UserMockData
    {
        public static IEnumerable<VBook2User> GetBooks()
        {
            return new List<VBook2User>
            {
                new VBook2User
                {
                    BookId = 1,
                    BookTitle =  "Reading chart patter",
                    Category =  "Finance",
                    Price =  500,
                    Content =  "Head and shoulder patters",
                    Active =  true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate =  DateTime.Now,
                    PublishDate =  DateTime.Now,
                    Publisher = "NSE and BSE"
                },
                new VBook2User
                {
                    BookId = 2,
                    BookTitle =  "Reading chart patter unit test",
                    Category =  "Finance one",
                    Price =  500,
                    Content =  "Head and shoulder patters test",
                    Active =  true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate =  DateTime.Now,
                    PublishDate =  DateTime.Now,
                    Publisher = "NSE"
                }
            };
        }

        public static List<VBook2User> EmptyBooks()
        {
            return new List<VBook2User>();
        }
    }
}
