namespace Reader.Models
{
    public partial class User
    {
        public User()
        {
        }

        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserType { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
