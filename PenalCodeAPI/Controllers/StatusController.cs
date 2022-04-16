using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PenalCodeAPI.Services;
using PenalCodeAPI.Converters;
using PenalCodeAPI.DTO;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatusController : ControllerBase
    {
        private readonly StatusService _statusService;
        private readonly StatusConverter _statusConverter;

        public StatusController(StatusService statusService, StatusConverter statusConverter)
        {
            _statusService = statusService;
            _statusConverter = statusConverter;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusDTO>>> Get()
        {
            try
            {
                var response = _statusService.GetAllStatus();

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
        public async Task<ActionResult<Status>> GetById(int id)
        {
            try
            {
                var response = _statusService.GetStatus(id);

                return Ok(_statusConverter.StatusToStatusDTO(response));
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
        public async Task<ActionResult<string>> AddStatus(StatusDTO statusDTO)
        {
            try
            {
                _statusService.CreateStatus(_statusConverter.StatusDTOToStatus(statusDTO));

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
        public async Task<ActionResult<string>> UpdateStatus(StatusDTO statusDTO)
        {
            try
            {
                _statusService.UpdateStatus(_statusConverter.StatusDTOToStatus(statusDTO));

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
        public async Task<ActionResult<string>> DeleteStatus(StatusDTO statusDTO)
        {
            try
            {
                _statusService.DeleteStatus(_statusConverter.StatusDTOToStatus(statusDTO));

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
