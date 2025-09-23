using Application.DTOS;
using Curate.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            var result = await _userService.Create(user);
            return Ok(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.ReadAll();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto user)
        {
            var result = await _userService.Update(id, user);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }
    }
}
