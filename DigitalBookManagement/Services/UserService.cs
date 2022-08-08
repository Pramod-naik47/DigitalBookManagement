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

        public string CreateUser(UserDetail userDetails)
        {
            try
            {
                _digitalBookManagementContext.UserDetails.Add(userDetails);
                _digitalBookManagementContext.SaveChanges();
            }
            catch (Exception e)
            {
                return $"Operation failed {e.Message}";
            }
            return "User saved";
        }
    }
}
