using Application.DTOS;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurateController : ControllerBase
    {
        private readonly IUser _user;
        public CurateController(IUser user)
        {
            _user = user;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            var result = await _user.Create(user);
            if (result)
            {
                return Ok("User created successfully");
            }
            return BadRequest("User creation failed");
        }
    }
}
