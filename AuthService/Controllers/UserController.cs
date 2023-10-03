using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;

        public UserController(ILogger<OrderController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            
            return Ok(user);
        }

        [HttpGet("{userId:int}")]
        public IActionResult GetUserById(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            return (user != null) ? Ok(user) : NotFound();
        }

        [HttpPut("{userId:int}")]
        public IActionResult UpdateUser(User user, int userId)
        {
            user.Id = userId;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            
            return Ok(user);
        }

        [HttpDelete("{userId:int}")]
        public IActionResult DeleteUser(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();

                return NoContent();
            }
        }
    }
}