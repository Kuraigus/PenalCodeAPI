using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.Status.ToListAsync());
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Status>> GetById(int id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound("Status nao encontrado!");
            }
            return Ok(status);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> AddStatus(Status status)
        {
            _context.Status.Add(status);
            await _context.SaveChangesAsync();

            return Ok("Sucesso em adicionar Status!");
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> UpdateStatus(Status request)
        {
            var dbStatus = await _context.Status.FindAsync(request.Id);
            if (dbStatus == null)
            {
                return NotFound("Status nao encontrado!");
            }

            dbStatus.Name = request.Name;

            await _context.SaveChangesAsync();

            return Ok("Sucesso em atualizar user!");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> DeleteStatus(int id)
        {
            var dbStatus = await _context.Status.FindAsync(id);
            if (dbStatus == null)
            {
                return NotFound("Status nao encontrado!");
            }

            _context.Status.Remove(dbStatus);
            await _context.SaveChangesAsync();
            return Ok("Sucesso em apagar Status!");
        }
    }
}
