using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public interface IAuthorTokenService
    {
        Task<User> ValidateUser(string userName, string password, string userType);
        Task<User> CheckExistingUser(string userName, string userType);
    }
}