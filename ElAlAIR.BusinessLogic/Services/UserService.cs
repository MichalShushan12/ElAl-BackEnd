using AutoMapper;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DataAccess.Interfaces;
using ElAlAIR.DataAccess.Repositories;
using ElAlAIR.DTO.Models;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateUser(UserDTO user)
        {
            try
            {
                user.UserId = Guid.NewGuid();
                return await _userRepository.CreateUser(_mapper.Map<User>(user));
            }
            catch (Exception)
            {
                throw;
            }

            //try
            //{
            //    user.UserId = Guid.NewGuid();
            //    return await _userRepository.CreateUser(_mapper.Map<User>(user));

            //    //User createdUser =  _userRepository.CreateUser(_mapper.Map<User>(user));
            //    //return _mapper.Map<UserDTO>(createdUser);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public async Task<List<UserDTO>> GetUser()
        {
            try
            {
                List<User> usersList = await _userRepository.GetUser();
                return _mapper.Map<List<UserDTO>>(usersList);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }


        public async Task<UserDTO> GetUserById(Guid userId)
        {
            try
            {
                User userID = await _userRepository.GetUserById(userId);
                return _mapper.Map<UserDTO>(userID);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            try
            {
                User updateUser = await _userRepository.UpdateUser(_mapper.Map<User>(user));
                return _mapper.Map<UserDTO>(updateUser);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<UserDTO> GetUserByUserName(string userName)
        {
            try
            {
                User UserNameOfUser = await _userRepository.GetUserByUserName(userName);
                return _mapper.Map<UserDTO>(UserNameOfUser);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        //public async Task<UserDTO> GetUserByEmail(string email)
        //{
        //    try
        //    {
        //        User EmailOfUser = await _userRepository.GetUserByEmail(email);
        //        return _mapper.Map<UserDTO>(EmailOfUser);
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error creating order", ex);
        //    }
        //}
    }
}

