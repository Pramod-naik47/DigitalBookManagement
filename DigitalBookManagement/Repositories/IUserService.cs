using DigitalBookManagement.Model;

namespace DigitalBookManagement.Repositories
{
    public interface IUserService
    {
        string CreateUser(UserDetail userDetails);
    }
}