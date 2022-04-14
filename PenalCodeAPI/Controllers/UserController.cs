using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.User.ToListAsync());
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound("User nao encontrado!");
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> AddCriminalCode(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Sucesso em adicionar usuario!");
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateCriminalCode(User request)
        {
            var dbUser = await _context.User.FindAsync(request.Id);
            if (dbUser == null)
            {
                return NotFound("User nao encontrado!");
            }

            dbUser.UserName = request.UserName;
            dbUser.Password = request.Password;
            
            await _context.SaveChangesAsync();

            return Ok("Sucesso em atualizar user!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var dbUser = await _context.CriminalCodes.FindAsync(id);
            if (dbUser == null)
            {
                return NotFound("User nao encontrado!");
            }

            _context.CriminalCodes.Remove(dbUser);
            await _context.SaveChangesAsync();
            return Ok("Sucesso em apagar user!");
        }
    }
}
