using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Services;
using User.Domain.Models.Requests;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = await _userService.RegisterAsync(request);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
        {
            var user = await _userService.UpdateAsync(id, request);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var success = await _userService.ResetPasswordAsync(request);
            return success ? Ok("Password reset successful.") : NotFound("Email not found.");
        }

        [HttpPut("{id}/change-role")]
        [Authorize(Policy = "AdminOnly")] //  tylko administrator może awansować innych
        public async Task<IActionResult> ChangeUserRoleAsync(int id, string newRole)
        {
            var success = await _userService.ChangeUserRoleAsync(id, newRole);
            return success ? Ok("User role changed.") : NotFound("User not found.");
        }

    }
}