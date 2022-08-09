using Microsoft.EntityFrameworkCore;

namespace TokenAuthentication.Models
{
    public class TokenAuthenticationDbContext : DbContext
    {
        public TokenAuthenticationDbContext()
        {
        }

        public TokenAuthenticationDbContext(DbContextOptions<TokenAuthenticationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET664;Initial Catalog=DigitalBookManagement;Persist Security Info=True;User ID=sa;Password=pass@word1");
            }
        }
    }
}
