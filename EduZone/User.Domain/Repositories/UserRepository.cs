using Microsoft.EntityFrameworkCore;
using User.Domain.Models.UserModel;

namespace User.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccount?> GetByIdAsync(int id) =>
            await _context.UserAccounts.FindAsync(id);

        public async Task<UserAccount?> GetByUsernameAsync(string username) =>
            await _context.UserAccounts.FirstOrDefaultAsync(u => u.Username == username);

        public async Task<UserAccount?> GetByEmailAsync(string email) =>
            await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(UserAccount useraccount)
        {
            _context.UserAccounts.Add(useraccount);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserAccount useraccount)
        {
            _context.UserAccounts.Update(useraccount);
            await _context.SaveChangesAsync();
        }
    }
}