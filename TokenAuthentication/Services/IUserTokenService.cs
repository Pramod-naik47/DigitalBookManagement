using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public interface IUserTokenService
    {
        bool ValidateUser(string userName, string password);
    }
}