using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetUser();
        public Task<UserDTO> GetUserById(Guid userId);
        public Task<Guid> CreateUser(UserDTO user);
        public Task<UserDTO> UpdateUser(UserDTO user);

        public Task<UserDTO> GetUserByUserName(string userName);
        //public Task<UserDTO> GetUserByEmail(string email);

    }
}
