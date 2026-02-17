using Microsoft.AspNetCore.Mvc;
using WalkMyDog.Api.DTOs;

namespace WalkMyDog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "Gaf-Gaf! API is working!" });
        }
        
        [HttpGet("add")]
        public IActionResult Sum([FromQuery] SumRequestDto requestDto)
        {
            // .NET автоматически сконвертирует строки из URL в числа int
            int result = requestDto.A + requestDto.B;

            return Ok(new 
            { 
                operation = "Sum of two numbers",
                sum = result,
                message = "Gaf-Gaf! I calculated it for you!"
            });
        }
    }
}
