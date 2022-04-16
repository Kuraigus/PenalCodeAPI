using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PenalCodeAPI.Converters;
using PenalCodeAPI.DTO;
using PenalCodeAPI.Services;
using System.Security.Claims;

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
            try
            {
                var response = _criminalCodeService.GetCriminalCodes(page, sort, filter);

                return Ok(response);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<CriminalCodeDTO>> GetById(int id)
        {
            try
            {
                var response = _criminalCodeService.GetCriminalCode(id);

                return Ok(_criminalCodeConverter.CriminalCodeToCriminalCodeDTO(response));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> AddCriminalCode(CriminalCodeDTO criminalCodeDTO)
        {
            try
            {
                var claims = User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault();
                _criminalCodeService.CreateCriminalCode(_criminalCodeConverter.CriminalCodeDTOToCriminalCode(criminalCodeDTO), claims.Value);

                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> UpdateCriminalCode(CriminalCodeDTO criminalCodeDTO)
        {
            try
            {
                var claims = User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault();
                _criminalCodeService.UpdateCriminalCode(_criminalCodeConverter.CriminalCodeDTOToCriminalCode(criminalCodeDTO), claims.Value);
             
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                _criminalCodeService.DeleteCriminalCode(id);

                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
