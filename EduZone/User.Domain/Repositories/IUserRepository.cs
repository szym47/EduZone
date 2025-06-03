using User.Domain.Models;
using User.Domain.Models.UserModel;

namespace User.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserAccount?> GetByIdAsync(int id);
        Task<UserAccount?> GetByUsernameAsync(string username);
        Task<UserAccount?> GetByEmailAsync(string email);
        Task AddAsync(UserAccount usseraccount);
        Task UpdateAsync(UserAccount useraccount);
    }
}
