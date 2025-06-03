using Microsoft.EntityFrameworkCore;
using User.Domain.Models.UserModel;

namespace User.Domain.Repositories
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
