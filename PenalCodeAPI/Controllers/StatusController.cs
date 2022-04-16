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
            var response = _statusService.GetAllStatus();

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Status>> GetById(int id)
        {
            var response = _statusService.GetStatus(id);

            if (response == null)
                return BadRequest();

            return Ok(_statusConverter.StatusToStatusDTO(response));
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> AddStatus(StatusDTO statusDTO)
        {
            var response = _statusService.CreateStatus(_statusConverter.StatusDTOToStatus(statusDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> UpdateStatus(StatusDTO statusDTO)
        {
            var response = _statusService.UpdateStatus(_statusConverter.StatusDTOToStatus(statusDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> DeleteStatus(StatusDTO statusDTO)
        {
            var response = _statusService.DeleteStatus(_statusConverter.StatusDTOToStatus(statusDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }
    }
}
