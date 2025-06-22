using System.Security.Cryptography;
using System.Text;
using User.Domain.Models.UserModel;
using User.Domain.Repositories;

namespace User.Domain.Seeders
{
    public class UserSeeder : IUserSeeder
    {
        private readonly IUserRepository _repository;

        public UserSeeder(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Seed()
        {
            var admin = await _repository.GetByUsernameAsync("admin");
            if (admin != null) return;

            var password = "password";
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashed = Convert.ToBase64String(sha.ComputeHash(bytes));

            var user = new UserAccount
            {
                Username = "admin",
                FullName = "Administrator",
                Email = "admin@example.com",
                Password = hashed,
                Role = "Admin"
            };

            await _repository.AddAsync(user);
        }
    }
}
