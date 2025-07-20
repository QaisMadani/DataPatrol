using API.DTOs;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public PolicyController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetAll()
        {
            var list = await _uow.Policies.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{PolicyID}")]
        public async Task<ActionResult<Policy>> GetById(string PolicyID)
        {
            var pol = await _uow.Policies.GetByIdAsync(PolicyID);
            if (pol == null) return NotFound();
            return Ok(pol);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePolicyDto dto)
        {
            var pol = new Policy
            {
                PolicyId = dto.PolicyId,
                PolicyName = dto.PolicyName,
                IsDefault = dto.IsDefault,
                PolicyType = dto.PolicyType,
                IsEnabled = dto.IsEnabled
            };
            await _uow.Policies.AddAsync(pol);
            await _uow.CompleteAsync();
            return CreatedAtAction(nameof(GetById), new { id = pol.PolicyId }, pol);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Policy>> Update(string id, [FromBody] UpdatePolicyDto dto)
        {
            var pol = await _uow.Policies.GetByIdAsync(id);
            if (pol == null) return NotFound();
            pol.PolicyName = dto.PolicyName;
            pol.IsDefault = dto.IsDefault;
            pol.PolicyType = dto.PolicyType;
            pol.IsEnabled = dto.IsEnabled;
            _uow.Policies.Update(pol);
            await _uow.CompleteAsync();
            return Ok(pol);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var pol = await _uow.Policies.GetByIdAsync(id);
            if (pol == null) return NotFound();
            _uow.Policies.Remove(pol);
            await _uow.CompleteAsync();
            return NoContent();
        }

        [HttpPost("{id}/groups")]
        public async Task<IActionResult> AssignGroups(string id, [FromBody] List<string> groupIds)
        {
            if (await _uow.Policies.GetByIdAsync(id) == null) return NotFound();
            await _uow.CompleteAsync();
            return NoContent();
        }
    }
}
