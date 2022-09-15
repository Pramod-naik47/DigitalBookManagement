using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReaderApiTestCase.Helper
{
    public static class MockHttpContext
    {
        public static DefaultHttpContext DefaultMockHttpContext()
        {
            var httpContext = new DefaultHttpContext();
            var identity = httpContext.User.Identities.FirstOrDefault();
            
            if (identity != null)
            {
                List<Claim> claims = MockIdentityClaims.MockClaims();
                identity.AddClaims(claims);
            }
            return httpContext;
        }
    }
}
