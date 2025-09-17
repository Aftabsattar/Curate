using Curate.Contex;
using Curate.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurateController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CurateController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user) 
        {
            await _dbContext.user.AddAsync(user);
            _dbContext.SaveChanges();
            return Ok("User Added Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _dbContext.user.ToListAsync();
            return Ok(user);
        }
    }
}
