using System.ComponentModel.DataAnnotations;

namespace TokenAuthentication.Models
{
    public class UserDetail
    {
        public UserDetail()
        {
        }
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;
    }
}
