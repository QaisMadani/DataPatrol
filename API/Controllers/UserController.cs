using API.DTOs;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _uow.Users.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAUserByID(string id)
        {
            var user = await _uow.Users.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("reg")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var baseId = dto.Username.Trim().ToLower().Replace(" ", "_");
            var candidate = baseId;
            var suffix = 1;
            while (await _uow.Users.GetByIdAsync(candidate) != null)
                candidate = $"{baseId}_{suffix++}";
            var user = new User
            {
                UserId = candidate,
                Username = dto.Username,
                IsEnabled = true,
                CreatedDateTime = DateTime.UtcNow
            };
            await _uow.Users.AddAsync(user);
            await _uow.CompleteAsync();
            return Ok(new { user.UserId, user.IsEnabled });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> EditUser(string id, [FromBody] UserDto dto)
        {
            var user = await _uow.Users.GetByIdAsync(id);
            if (user == null) return NotFound();
            user.Username = dto.Username;
            _uow.Users.Update(user);
            await _uow.CompleteAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _uow.Users.GetByIdAsync(id);
            if (user == null) return NotFound();
            _uow.Users.Remove(user);
            await _uow.CompleteAsync();
            return NoContent();
        }

        [HttpPut("{id}/toggle")]
        public async Task<IActionResult> ToggleEnabled(string id)
        {
            var user = await _uow.Users.GetByIdAsync(id);
            if (user == null) return NotFound();
            user.IsEnabled = !user.IsEnabled;
            _uow.Users.Update(user);
            await _uow.CompleteAsync();
            return Ok(new { user.UserId, user.IsEnabled });
        }

        [HttpGet("{id}/requests")]
        public async Task<ActionResult<IEnumerable<UserRequest>>> GetRequests(string id)
        {
            var list = await _uow.Requests.FindAsync(r => r.RequestedBy == id);
            return Ok(list);
        }

        [HttpPost("{id}/groups")]
        public async Task<IActionResult> AssignGroups(string id, [FromBody] List<string> groupIds)
        {
            if (await _uow.Users.GetByIdAsync(id) == null) return NotFound();
            _uow.Dispose(); // use underlying context for join-tables
            return NoContent();
        }
    }
}
