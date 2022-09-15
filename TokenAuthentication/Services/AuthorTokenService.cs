using Microsoft.EntityFrameworkCore;
using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public class AuthorTokenService : IAuthorTokenService
    {
        public TokenAuthenticationDbContext _tokenAuthenticationDbContext { get; set; }
        public AuthorTokenService(TokenAuthenticationDbContext tokenAuthenticationDbContext)
        {
            _tokenAuthenticationDbContext = tokenAuthenticationDbContext;
        }

        public async Task<User> ValidateUser(string userName, string password, string userType)
        {
            var result = await _tokenAuthenticationDbContext.Users.Where(x => x.UserName == userName && x.Password == password && x.UserType == userType).ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<User> CheckExistingUser(string userName, string userType)
        {
            var result = await _tokenAuthenticationDbContext.Users.Where(x => x.UserName == userName && x.UserType == userType).ToListAsync();

            return result.FirstOrDefault();
;        }


    }
}
