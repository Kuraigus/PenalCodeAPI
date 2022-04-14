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
        public async Task<ActionResult<List<CriminalCode>>> Get(int page, string? sort, string? filter)
        {
            var pageResults = 5f;
            var pageCount = Math.Ceiling(_context.CriminalCodes.Count() / pageResults);

            var codes = await _context.CriminalCodes
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            if (sort != null)
            {
                if (sort == "name")
                {
                    codes = codes.OrderBy(c => c.Name).ToList();
                }
                else if (sort == "createDate")
                {
                    codes = codes.OrderBy(c => c.CreateDate).ToList();
                }
                else if (sort == "updateDate")
                {
                    codes = codes.OrderBy(c => c.UpdateDate).ToList();
                }
                else if (sort == "createdByUserId")
                {
                    codes = codes.OrderBy(c => c.CreateUserId).ToList();
                }
                else if (sort == "updatedByUserId")
                {
                    codes = codes.OrderBy(c => c.UpdateUserId).ToList();
                }
                else if (sort == "statusId")
                {
                    codes = codes.OrderBy(c => c.StatusId).ToList();
                }
                else if (sort == "penalty")
                {
                    codes = codes.OrderBy(c => c.Penalty).ToList();
                }
                else if (sort == "prisonTime")
                {
                    codes = codes.OrderBy(c => c.PrisonTime).ToList();
                }
            }

            if (filter != null)
            {
                codes = codes.Where(c => c.Name.Contains(filter) ||
                                    c.CreateUserId.Contains(filter) ||
                                    c.UpdateUserId.Contains(filter) ||
                                    c.StatusId.Contains(filter)).ToList();
            }

            var response = new CriminalCodeResponse
            {
                CriminalCodes = codes,
                CurrentPage = page,
                Pages = (int)pageCount
            };


            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<CriminalCode>> GetById(int id)
        {
            var criminalCode = await _context.CriminalCodes.FindAsync(id);
            if (criminalCode == null)
            {
                return NotFound("Codigo nao encontrado!");
            }
            return Ok(criminalCode);
        }


        [HttpPost]
        public async Task<ActionResult<string>> AddCriminalCode(CriminalCode criminalCode)
        {
            _context.CriminalCodes.Add(criminalCode);
            await _context.SaveChangesAsync();

            return Ok("Sucesso em adicionar codigo penal!");
        }

        [HttpPut]
        public async Task<ActionResult<string>> UpdateCriminalCode(CriminalCode request)
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
            dbCriminalCode.PrisonTime =  request.PrisonTime;
            dbCriminalCode.Penalty = request.Penalty;
            dbCriminalCode.StatusId = request.StatusId;

            await _context.SaveChangesAsync();

            return Ok("Sucesso em atualizar codigo penal!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var dbCriminalCode = await _context.CriminalCodes.FindAsync(id);
            if (dbCriminalCode == null)
            {
                return NotFound("Codigo nao encontrado!");
            }

            _context.CriminalCodes.Remove(dbCriminalCode);
            await _context.SaveChangesAsync();
            return Ok("Sucesso em apagar codigo penal!");
        }
    }
}
