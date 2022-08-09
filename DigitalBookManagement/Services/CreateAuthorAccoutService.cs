using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;

namespace DigitalBookManagement.Services
{
    public class CreateAuthorAccoutService : ICreateAuthorAccout
    {
        public DigitalBookManagementContext _digitalBookManagementContext { get; set; }
        public CreateAuthorAccoutService(DigitalBookManagementContext digitalBookManagementContext)
        {
            _digitalBookManagementContext = digitalBookManagementContext;
        }

        public string CreateAuthor(Author userDetails)
        {
            try
            {
                _digitalBookManagementContext.Author.Add(userDetails);
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
