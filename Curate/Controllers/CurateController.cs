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

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto user)
        {
            var result = await _user.Update(id, user);
            if (!result)
            {
                return BadRequest("User update failed");
            }
            return Ok(result);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _user.Delete(id);
            if (!result)
            {
                return BadRequest("User deletion failed");
            }
            return Ok(result);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _user.GetAll();
            return Ok(result);
        }
    }
}
