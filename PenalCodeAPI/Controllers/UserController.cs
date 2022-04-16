using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PenalCodeAPI.Services;
using PenalCodeAPI.DTO;
using PenalCodeAPI.Converters;

namespace PenalCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly UserConverter _userConverter;

        public UserController(UserService userService, UserConverter userConverter)
        {
            _userService = userService;
            _userConverter = userConverter;
        }

        [HttpGet("getById/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var response = _userService.GetUser(id);

            if (response == null)
                return BadRequest();

            return Ok(_userConverter.UserToUserDTO(response));
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(UserDTO userDTO)
        {
            var response = _userService.login(_userConverter.UserDTOToUser(userDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPost("register")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterUser(UserDTO userDTO)
        {
            var response = _userService.CreateUser(_userConverter.UserDTOToUser(userDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<string>> UpdateUser(UserDTO request)
        {
            var response = _userService.UpdateUser(_userConverter.UserDTOToUser(request));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> DeleteUser(UserDTO userDTO)
        {
            var response = _userService.DeleteUser(_userConverter.UserDTOToUser(userDTO));

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

    }
}
