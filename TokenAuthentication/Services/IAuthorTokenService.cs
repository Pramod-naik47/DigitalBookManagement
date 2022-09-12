using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public interface IAuthorTokenService
    {
        User ValidateUser(string userName, string password, string userType);
        User CheckExistingUser(string userName, string userType);
    }
}