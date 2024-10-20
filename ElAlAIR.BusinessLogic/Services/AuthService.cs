using AutoMapper;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DataAccess.Interfaces;
using ElAlAIR.DataAccess.Repositories;
using ElAlAIR.DTO.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;   
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<TokenDTO> Login(UserLoginDTO loginUser)
        {
            var user = await _userRepository.GetUserByUserName(loginUser.UserName);
            UserDTO userByUserName = _mapper.Map<UserDTO>(user);

            if (userByUserName == null)
            {
                throw new Exception("The username or password is invalid");
            }

            if (userByUserName.Password == loginUser.Password)
            {
                return await AuthenticateUser(userByUserName);
            }

            throw new Exception("The username or password is invalid");
        }

        private async Task<TokenDTO> AuthenticateUser(UserDTO user)
        {
            //TODO: Remove old token or remark old token-is not validy;
            string jwtToken = GenerateJwtToken(user);
            TokenDTO token = new TokenDTO
            {
                TokenId = Guid.NewGuid(),
                UserId = user.UserId,
                TokenJwt = jwtToken,
                ExpireDate = DateTime.Now.AddDays(1)
            };
            return token;
        }

        private string GenerateJwtToken(UserDTO user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            List<Claim> claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
             // new Claim(ClaimTypes.Role, user.Role.Name)
            };
            //SymmetricSecurityKey signingKey = new SymmetricSecurityKey(key);
            //SigningCredentials signingKeyCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken
                (
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );

            string accessTokenValue = tokenHandler.WriteToken(token);
            return accessTokenValue;
        }


        public async Task <Guid> RegisterUser(UserDTO newUser)
        {
            try
            {
                newUser.UserId = Guid.NewGuid();
                return await _userRepository.CreateUser(_mapper.Map<User>(newUser));
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDto)
        {
            try
            {
                // Check if the new password and confirm password match
                if (updatePasswordDto.NewPassword != updatePasswordDto.ConfirmNewPassword)
                {
                    throw new Exception("New password and confirm password do not match.");
                }

                var user = await _userRepository.GetUserByUserName(updatePasswordDto.UserName);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                // Verify the current password matches
                if (user.Password != updatePasswordDto.CurrentPassword)
                {
                    throw new Exception("Current password is incorrect.");
                }

                // Update the password
                user.Password = updatePasswordDto.NewPassword;

                // Save the changes to the repository
                var updateResult = await _userRepository.UpdateUser(user);

                // Return true if the update is successful, otherwise false
                return updateResult != null;
            }

            catch (Exception ex)
            {
                throw new Exception($"Error updating password: {ex.Message}");
            }
        }

    }
}
