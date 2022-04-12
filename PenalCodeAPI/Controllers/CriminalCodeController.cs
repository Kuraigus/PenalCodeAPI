using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalCodeController : ControllerBase
    {
        private readonly DataContext _context;

        public CriminalCodeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CriminalCode>>> Get()
        {
            return Ok(await _context.CriminalCodes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CriminalCode>> Get(int id)
        {
            var criminalCode = _context.CriminalCodes.FindAsync(id);
            if (criminalCode == null)
            {
                return NotFound("Codigo nao encontrado!");
            }
            return Ok(criminalCode);
        }


        [HttpPost]
        public async Task<ActionResult<List<CriminalCode>>> AddCriminalCode(CriminalCode criminalCode)
        {
            _context.CriminalCodes.Add(criminalCode);
            await _context.SaveChangesAsync();

            return Ok(await _context.CriminalCodes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<CriminalCode>>> UpdateCriminalCode(CriminalCode request)
        {
            var dbCriminalCode = await _context.CriminalCodes.FindAsync(request.Id);
            if (dbCriminalCode == null)
            {
                return NotFound("Codigo nao encontrado!");
            }

            dbCriminalCode.Name = request.Name;
            dbCriminalCode.Description = request.Description;
            dbCriminalCode.UpdateDate = request.UpdateDate;
            dbCriminalCode.UpdateUserId = request.UpdateUserId;
            dbCriminalCode.Prisontime =  request.Prisontime;
            dbCriminalCode.Penalty = request.Penalty;
            dbCriminalCode.StatusId = request.StatusId;

            await _context.SaveChangesAsync();

            return Ok(await _context.CriminalCodes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CriminalCode>>> Delete(int id)
        {
            var dbCriminalCode = await _context.CriminalCodes.FindAsync(id);
            if (dbCriminalCode == null)
            {
                return NotFound("Codigo nao encontrado!");
            }

            _context.CriminalCodes.Remove(dbCriminalCode);
            await _context.SaveChangesAsync();
            return Ok(await _context.CriminalCodes.ToListAsync());
        }
    }
}
