using CoreManager.API.CoreManager.Application.Services;
using CoreManager.API.CoreManager.Domain.DTOs;
using CoreManager.API.CoreManager.Domain.Interfaces;
using CoreManager.API.CoreManager.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreManager.API.CoreManager.WebApplication.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminAuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AdminAuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginAdminDto loginDto)
        {
            var token = await _authService.Authenticate(loginDto);
            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }
    }
}
