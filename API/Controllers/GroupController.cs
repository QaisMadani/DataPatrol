using API.DTOs;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public GroupController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserGroup>>> GetAll()
        {
            var groups = await _uow.Groups.GetAllAsync();
            return Ok(groups);
        }

        [HttpGet("{GroupID}")]
        public async Task<ActionResult<UserGroup>> GetById(string GroupID)
        {
            var grp = await _uow.Groups.GetByIdAsync(GroupID);
            if (grp == null) return NotFound();
            return Ok(grp);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGroupDto dto)
        {
            var grp = new UserGroup { GroupId = dto.GroupId, Description = dto.Description };
            await _uow.Groups.AddAsync(grp);
            await _uow.CompleteAsync();
            return CreatedAtAction(nameof(GetById), new { id = grp.GroupId }, grp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserGroup>> Update(string id, [FromBody] UpdateGroupDto dto)
        {
            var grp = await _uow.Groups.GetByIdAsync(id);
            if (grp == null) return NotFound();
            grp.Description = dto.Description;
            _uow.Groups.Update(grp);
            await _uow.CompleteAsync();
            return Ok(grp);
        }

        [HttpDelete("{GroupID}")]
        public async Task<IActionResult> Delete(string GroupID)
        {
            var grp = await _uow.Groups.GetByIdAsync(GroupID);
            if (grp == null) return NotFound();
            _uow.Groups.Remove(grp);
            await _uow.CompleteAsync();
            return NoContent();
        }

        [HttpPost("{id}/users")]
        public async Task<IActionResult> AssignUsers(string id, [FromBody] List<string> userIds)
        {
            if (await _uow.Groups.GetByIdAsync(id) == null) return NotFound();
            await _uow.CompleteAsync();
            return NoContent();
        }

        [HttpPost("{id}/policies")]
        public async Task<IActionResult> AssignPolicies(string id, [FromBody] List<string> policyIds)
        {
            if (await _uow.Groups.GetByIdAsync(id) == null) return NotFound();
            await _uow.CompleteAsync();
            return NoContent();
        }
    }
}
