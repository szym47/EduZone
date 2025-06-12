using System.Security.Cryptography;
using System.Text;
using User.Domain.Exceptions.Login;
using User.Domain.Repositories;

namespace User.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !VerifyPassword(password, user.Password))
                throw new InvalidCredentialsException();

            var roles = new List<string> { user.Role }; // np. "Admin", "Client"
            return _jwtTokenService.GenerateToken(user.Id, roles);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = Convert.ToBase64String(sha.ComputeHash(bytes));
            return hash == hashedPassword;
        }
    }
}
