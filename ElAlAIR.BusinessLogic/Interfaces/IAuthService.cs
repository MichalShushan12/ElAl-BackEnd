using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        //public Task<TokenDTO> RegisterUser(UserDTO newUser);
        public Task<TokenDTO> Login(UserLoginDTO loginUser);

        public Task<Guid> RegisterUser(UserDTO newUser);

        public Task<bool> UpdatePassword(UpdatePasswordDTO updatePasswordDto);

        //Task<UserDTO> SignUp(UserDTO user);

        //public Task<UserDTO> RegisterUser(UserDTO newUser);
        //Task<UserDto> Login(LoginRequest request);
        //Task UpdatePassword(Guid userId, UpdatePasswordRequest request);
    }
}
