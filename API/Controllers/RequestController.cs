// RequestController.cs
using API.DTOs;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RequestController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRequest>>> GetAll()
        {
            var list = await _uow.Requests.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{requestID:long}")]
        public async Task<ActionResult<UserRequest>> GetById(long requestID)
        {
            var req = await _uow.Requests.GetByIdAsync(requestID);
            if (req == null) return NotFound();
            return Ok(req);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRequestDto dto)
        {
            var r = new UserRequest
            {
                RequestedBy = dto.UserId,
                RequestDateTime = DateTime.UtcNow,
                RequestCode = dto.RequestCode,
                Description = dto.Description,
                Status = RequestStatus.Draft
            };
            await _uow.Requests.AddAsync(r);
            await _uow.CompleteAsync();
            return CreatedAtAction(nameof(GetById), new { requestID = r.RequestId }, r);
        }

        [HttpPut("{requestID:long}")]
        public async Task<IActionResult> Update(long requestID, [FromBody] UpdateRequestDto dto)
        {
            var r = await _uow.Requests.GetByIdAsync(requestID);
            if (r == null) return NotFound();
            if (r.Status != RequestStatus.Draft && r.Status != RequestStatus.InReview)
                return BadRequest();
            r.RequestCode = dto.RequestCode;
            r.Description = dto.Description;
            _uow.Requests.Update(r);
            await _uow.CompleteAsync();
            return Ok(r);
        }

        [HttpDelete("{requestID:long}")]
        public async Task<IActionResult> Delete(long requestID)
        {
            var r = await _uow.Requests.GetByIdAsync(requestID);
            if (r == null) return NotFound();
            _uow.Requests.Remove(r);
            await _uow.CompleteAsync();
            return NoContent();
        }

        [HttpPost("summary")]
        public async Task<IActionResult> Summary([FromBody] SummaryRequestDto dto)
        {
            var counts = (await _uow.Requests.FindAsync(r => r.RequestedBy == dto.UserId))
                .GroupBy(r => r.Status)
                .ToDictionary(g => g.Key.ToString(), g => g.Count());
            return Ok(counts);
        }
    }
}
