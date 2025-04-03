using CoreManager.API.CoreManager.Domain.DTOs;
using CoreManager.API.CoreManager.Domain.Interfaces;
using CoreManager.API.CoreManager.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreManager.API.CoreManager.WebApplication.Controllers
{
    [ApiController]
    [Route("api/admin/users")]
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : ControllerBase
    {
        private readonly IAdminUserRepository _repository;

        public AdminUsersController(IAdminUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllAsync();
            var result = users.Select(u => new AdminUserDto
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            var dto = new AdminUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAdminUserDto dto)
        {
            var hasher = new PasswordHasher<AdminUser>();
            var user = new AdminUser
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email
            };
            user.PasswordHash = hasher.HashPassword(user, dto.Password);

            await _repository.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, new AdminUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateAdminUserDto dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return NotFound();

            user.Username = dto.Username;
            user.Email = dto.Email;

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                var hasher = new PasswordHasher<AdminUser>();
                user.PasswordHash = hasher.HashPassword(user, dto.Password);
            }

            await _repository.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
