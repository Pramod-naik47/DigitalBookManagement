using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAuthentication.Models;

namespace TokenAuthenticationTestCase.MockData
{
    public static class UserMockData
    {
        public static User GetUser()
        {
            return new User
            {
                UserId = 1,
                UserName = "Pramod",
                Password = "1234",
                UserType = "Author"
            };
        }
    }
}
