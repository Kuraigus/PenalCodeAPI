using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenalCodeAPI.Converters;
using PenalCodeAPI.DTO;
using PenalCodeAPI.Services;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CriminalCodeController : ControllerBase
    {
        private readonly CriminalCodeService _criminalCodeService;
        private readonly CriminalCodeConverter _criminalCodeConverter;

        public CriminalCodeController(CriminalCodeService criminalCodeService, CriminalCodeConverter criminalCodeConverter)
        {
            _criminalCodeService = criminalCodeService;
            _criminalCodeConverter = criminalCodeConverter;
        }

        [HttpGet]
        public async Task<ActionResult<List<CriminalCodeDTO>>> Get(int page, string? sort, string? filter)
        {
           var response = _criminalCodeService.GetCriminalCodes(page, sort, filter);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<CriminalCodeDTO>> GetById(int id)
        {
            var response = _criminalCodeService.GetCriminalCode(id);

            if (response == null)
                return BadRequest();

            return Ok(_criminalCodeConverter.CriminalCodeToCriminalCodeDTO(response));
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> AddCriminalCode(CriminalCodeDTO criminalCodeDTO)
        {
            var response = _criminalCodeService.CreateCriminalCode(_criminalCodeConverter.CriminalCodeDTOToCriminalCode(criminalCodeDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> UpdateCriminalCode(CriminalCodeDTO criminalCodeDTO)
        {
            var response = _criminalCodeService.UpdateCriminalCode(_criminalCodeConverter.CriminalCodeDTOToCriminalCode(criminalCodeDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var response = _criminalCodeService.DeleteCriminalCode(id);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
    }
}
