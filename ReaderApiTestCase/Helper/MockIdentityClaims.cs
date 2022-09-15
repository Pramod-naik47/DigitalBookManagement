using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReaderApiTestCase.Helper
{
    public static class MockIdentityClaims
    {
        public static List<Claim> MockClaims()
        {
            return new List<Claim>
            {
                new Claim("UserName", "Pramod"),
                new Claim("UserType","Reader"),
                new Claim("UserId", "1"),
            };

        }
    }
}
