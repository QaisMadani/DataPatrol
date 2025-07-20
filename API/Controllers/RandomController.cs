using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomController : ControllerBase
    {
        private readonly IRandomService _random;

        public RandomController(IRandomService random)
        {
            _random = random;
        }

        [HttpGet]
        public ActionResult<ResponseDto<RandomNumberDto>> Get()
        {
            var number = _random.Next();              // 1–100
            var payload = new ResponseDto<RandomNumberDto>
            {
                Data = new RandomNumberDto { Number = number }
            };
            return Ok(payload);
        }
    }
}