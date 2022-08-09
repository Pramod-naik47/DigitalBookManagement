using TokenAuthentication.Models;

namespace TokenAuthentication.Services
{
    public interface IAuthorTokenService
    {
        bool ValidateUser(string userName, string password);
    }
}