using AutoMapper;
using ElAlAIR.API.Models;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.BusinessLogic.Services;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElAlAIR.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUser()
        {
            try
            {

                var usersList = await _userService.GetUser();

                if (usersList == null)
                {
                    return NotFound();
                }

                return Ok(usersList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        


        [HttpGet("id/{userId}")]
        public async Task<ActionResult<UserDTO>> GetUserById(Guid userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);

                //return _userService.GetUserById(userId);
            }
            catch(Exception)
            {
                throw;
            }

        }

        [HttpGet("username/{userName}")]
        public async Task<ActionResult<UserDTO>> GetUserByUserName(string userName)
        {
            try
            {
                //var user = await _userRepository.GetUserByUserName(loginUser.UserName);
                //UserDTO userByUserName = _mapper.Map<UserDTO>(user);
                var UserByUserName = await _userService.GetUserByUserName(userName);

                if (UserByUserName == null)
                {
                    return NotFound();
                }

                return Ok(UserByUserName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet("email/{email}")]
        //public async Task<ActionResult<UserDTO>> GetUserByEmail(string email)
        //{
        //    try
        //    {
        //        var UserByEmail = await _userService.GetUserByEmail(email);

        //        if (UserByEmail == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(UserByEmail);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserRequest user)
        {
            try
            {
                var createUser = await _userService.CreateUser(_mapper.Map<UserDTO>(user));

                return Ok(createUser);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut("update")]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UserDTO user)
        {
            try
            {
                var updateUser = await _userService.UpdateUser(user);

                if (updateUser == null)
                {
                    return NotFound();
                }

                return Ok(updateUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

 

    }
}




