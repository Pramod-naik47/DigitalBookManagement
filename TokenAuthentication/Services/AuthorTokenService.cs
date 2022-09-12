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

        public User ValidateUser(string userName, string password, string userType)
        {
            var result = _tokenAuthenticationDbContext.Users.Where(x => x.UserName == userName && x.Password == password && x.UserType == userType).FirstOrDefault();

            return result;
        }

        public User CheckExistingUser(string userName, string userType)
        {
            var result = _tokenAuthenticationDbContext.Users.Where(x => x.UserName == userName && x.UserType == userType).FirstOrDefault();

            return result;
        }


    }
}
