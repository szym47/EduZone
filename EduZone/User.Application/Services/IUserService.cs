using User.Domain.Models;
using User.Domain.Models.Requests;
using User.Domain.Models.UserModel;

namespace User.Application.Services
{
    public interface IUserService
    {
        Task<UserAccount> RegisterAsync(RegisterRequest request);
        Task<UserAccount?> GetByIdAsync(int id);
        Task<UserAccount?> UpdateAsync(int id, UpdateUserRequest request);
        Task<bool> ResetPasswordAsync(ResetPasswordRequest request);
        Task<bool> ChangeUserRoleAsync(int id,ChangeRoleRequest request);

    }
}
