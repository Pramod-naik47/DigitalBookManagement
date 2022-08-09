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

        public string CreateAuthor(Author author)
        {
            try
            {
                _digitalBookManagementContext.Author.Add(author);
                _digitalBookManagementContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return $"Operation failed {ex.Message}";
            }
            return $"Author account for {author.UserName} created successfully";
        }
    }
}
