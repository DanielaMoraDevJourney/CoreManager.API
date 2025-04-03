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
        private readonly IAdminUserRepository _repository;
        private readonly IConfiguration _config;

        public AdminAuthController(IAdminUserRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginAdminDto loginDto)
        {
            var user = await _repository.GetByUsernameAsync(loginDto.Username);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var hasher = new PasswordHasher<AdminUser>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid credentials");

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
