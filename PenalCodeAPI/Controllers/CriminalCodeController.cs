using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PenalCodeAPI.DTO;
using PenalCodeAPI.Type;

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
        public async Task<ActionResult<List<CriminalCodeDTO>>> Get(int page, string? sort, string? filter)
        {
            var pageResults = 5f;
            var pageCount = Math.Ceiling(_context.CriminalCodes.Count() / pageResults);


            var codes = await _context.CriminalCodes
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            if (sort != null)
            {
                SortType sortType = SortType.none;

                switch (sortType.FromString(sort))
                {
                    case SortType.Name:
                        {
                            codes = codes.OrderBy(c => c.Name).ToList();
                            break;
                        }

                    case SortType.CreateDate:
                        {
                            codes = codes.OrderBy(c => c.CreateDate).ToList();
                            break;
                        }

                    case SortType.UpdateDate:
                        {
                            codes = codes.OrderBy(c => c.UpdateDate).ToList();
                            break;
                        }

                    case SortType.CreateUserId:
                        {
                            codes.OrderBy(c => c.CreateUserId).ToList();
                            break;
                        }

                    case SortType.UpdateUserId:
                        {
                            codes = codes.OrderBy(c => c.UpdateUserId).ToList();
                            break;
                        }

                    case SortType.StatusId:
                        {
                            codes = codes.OrderBy(c => c.StatusId).ToList();
                            break;
                        }

                    case SortType.Penalty:
                        {
                            codes = codes = codes.OrderBy(c => c.Penalty).ToList();
                            break;
                        }

                    case SortType.PrisonTime:
                        {
                            codes = codes.OrderBy(c => c.PrisonTime).ToList();
                            break;
                        }
                }
            }

            if (filter != null)
            {
                codes = codes.Where(c => c.Name.Contains(filter) ||
                                    c.CreateUserId.Contains(filter) ||
                                    c.UpdateUserId.Contains(filter) ||
                                    c.StatusId.Contains(filter)).ToList();
            }


            List<CriminalCodeDTO> criminalCodeDTOs = new List<CriminalCodeDTO>();

            foreach(var code in codes)
            {
                criminalCodeDTOs.Add(new CriminalCodeDTO
                {
                    Id = code.Id,
                    CreateDate = code.CreateDate,
                    CreateUserId = code.CreateUserId,
                    UpdateDate = code.UpdateDate,
                    UpdateUserId = code.UpdateUserId,
                    StatusId = code.StatusId,
                    Penalty = code.Penalty,
                    PrisonTime = code.PrisonTime,
                    Name = code.Name,
                    Description = code.Description,
                });
            }


            var response = new PageableResponse <CriminalCodeDTO>
            {
                Result = criminalCodeDTOs,
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
