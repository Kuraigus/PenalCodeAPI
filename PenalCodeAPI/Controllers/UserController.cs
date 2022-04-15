using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PenalCodeAPI.Services;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context, IConfiguration configuration)
        {
            _context = context;
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound("Status nao encontrado!");
            }

            user.Password = "";
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(User user)
        {
            var userData = _context.User.Where(u => u.UserName == user.UserName).FirstOrDefault();

            if (userData == null)
            {
                return NotFound("Usuario nao encontrado!");
            }

            if (userData.Password != user.Password)
            {
                return BadRequest("Senha errada!");
            }

            var token = TokenService.generateToken(userData);
            userData.Password = "";
            return Ok(new { user = userData, token = token });
        }

        [HttpPost("register")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuario criado com sucesso!");
        }

    }
}
