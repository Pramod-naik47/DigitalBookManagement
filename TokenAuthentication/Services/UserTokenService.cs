using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public class UserTokenService : IUserTokenService
    {
        public TokenAuthenticationDbContext _tokenAuthenticationDbContext { get; set; }
        public UserTokenService(TokenAuthenticationDbContext tokenAuthenticationDbContext)
        {
            _tokenAuthenticationDbContext = tokenAuthenticationDbContext;
        }

        public bool ValidateUser(string userName, string password)
        {
            var result = _tokenAuthenticationDbContext.UserDetails.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            return result != null ? true : false;
        }
    }
}
