using Azure.Core;
using System.Security.Cryptography;
using System.Text;
using User.Domain.Roles;
using User.Domain.Models.Requests;
using User.Domain.Models.UserModel;
using User.Domain.Repositories;


namespace User.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserAccount> RegisterAsync(RegisterRequest request)
        {
            var existing = await _repository.GetByUsernameAsync(request.Username);
            if (existing != null) throw new Exception("Username already exists");

            var user = new UserAccount
            {
                Username = request.Username,
                FullName = request.FullName,
                Email = request.Email,
                Password = HashPassword(request.Password),
                Role = "Client" // <== domyślna rola
            };

            await _repository.AddAsync(user);
            return user;
        }

        public async Task<UserAccount?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<UserAccount?> UpdateAsync(int id, UpdateUserRequest request)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            user.Email = request.Email;
            user.FullName = request.FullName;
            await _repository.UpdateAsync(user);
            return user;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _repository.GetByEmailAsync(request.Email);
            if (user == null) return false;

            user.Password = HashPassword(request.NewPassword);
            await _repository.UpdateAsync(user);
            return true;
        }


        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }

        public async Task<bool> ChangeUserRoleAsync(int userId, ChangeRoleRequest request)
        {
            if (!UserRoles.All.Contains(request.NewRole))
                throw new ArgumentException("Invalid role provided.");

            var user = await _repository.GetByIdAsync(userId);
            if (user == null) return false;

            user.Role = request.NewRole;
            await _repository.UpdateAsync(user);
            return true;
        }

    }
}