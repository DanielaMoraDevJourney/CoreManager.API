using CoreManager.API.CoreManager.Application.Services;
using CoreManager.API.CoreManager.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoreManager.API.CoreManager.WebApplication.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var dtoList = users.Select(UserMapper.ToDto);
            return Ok(dtoList);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(UserMapper.ToDto(user));
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto dto)
        {
            try
            {
                var user = UserMapper.ToDomain(dto);
                var created = await _userService.CreateAsync(user);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, UserMapper.ToDto(created));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            if (id != dto.Id)
                return BadRequest("El ID no coincide.");

            try
            {
                var user = UserMapper.ToDomain(dto);
                await _userService.UpdateAsync(user);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
