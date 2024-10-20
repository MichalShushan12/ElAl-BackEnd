using AutoMapper;
using Azure.Core;
using ElAlAIR.API.Models;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.BusinessLogic.Services;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElAlAIR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthService _authService;
        private IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService; 
            _mapper = mapper;
        }


        //[HttpPost("signUp")]
        //public Task<Guid> RegisterUser([FromBody] LoginRegisterRequest loginRegisterRequest)
        //{
        //    return _authService.RegisterUser(_mapper.Map<UserDTO>(loginRegisterRequest));
        //}


        [HttpPost("signUp")]
        public Task<Guid> RegisterUser([FromBody] LoginRegisterRequest loginRegisterRequest)
        {
            try
            {
                return _authService.RegisterUser(_mapper.Map<UserDTO>(loginRegisterRequest));
            }
            catch (Exception)
            {
                throw;
            }
        }    
    
        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login([FromBody] UserLoginDTO userLogin)
        {
            try
            {
                var result = await _authService.Login(userLogin);
                return Ok(result);
                //return _authService.Login(userLogin);

                //var userDto = await _authService.Login(userLogin);


                //if (userDto == null)
                //{
                //    return NotFound();
                //}

                //return Ok(userDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        //[HttpPost("signup")]
        //public async Task<ActionResult<UserDTO>> RegisterUser([FromBody] LoginRegisterRequest request)
        //{
        //    User user = await _authService.RegisterUser(request);
        //    return CreatedAtAction(nameof(RegisterUser), user);
        //}

        //[HttpPost("login")]
        //public async Task<ActionResult<UserLoginDTO>> Login(LoginRequest request)
        //{
        //    var user = await _userService.Login(request);
        //    return Ok(user);
        //}

        [HttpPut("updatePassword")]
        public async Task<ActionResult> UpdatePassword([FromBody] UpdatePasswordDTO updatePasswordDto)
        {
            try
            {
                var isUpdated = await _authService.UpdatePassword(updatePasswordDto);
                if (isUpdated) return Ok("Password updated successfully");
                return BadRequest("Failed to update password");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
