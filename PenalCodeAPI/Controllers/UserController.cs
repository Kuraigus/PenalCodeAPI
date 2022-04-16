﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var response = _userService.GetUser(id);

                return Ok(_userConverter.UserToUserDTO(response));
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

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(UserDTO userDTO)
        {
            try
            {
                var response = _userService.login(_userConverter.UserDTOToUser(userDTO));

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

        [HttpPost("register")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterUser(UserDTO userDTO)
        {
            try
            {
                _userService.CreateUser(_userConverter.UserDTOToUser(userDTO));

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
        [Authorize]
        public async Task<ActionResult<string>> UpdateUser(UserDTO request)
        {
            try
            {
                var response = _userService.UpdateUser(_userConverter.UserDTOToUser(request));

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

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> DeleteUser(UserDTO userDTO)
        {
            try
            {
                _userService.DeleteUser(_userConverter.UserDTOToUser(userDTO));

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
