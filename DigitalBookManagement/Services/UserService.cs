using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;

namespace DigitalBookManagement.Services
{
    public class UserService : IUserService
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public UserService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }
    }
}
