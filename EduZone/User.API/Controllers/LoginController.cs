﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application.Services;
using User.Domain.Exceptions.Login;
using User.Domain.Models.Requests;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        protected ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _loginService.Login(request.Username, request.Password);
                return Ok(new { token });
            }
            catch (InvalidCredentialsException)
            {
                return Unauthorized();
            }
        }


        [HttpGet]
        [Authorize]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AdminPage()
        {
            return Ok();
        }
    }
}
