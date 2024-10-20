using Azure.Core;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUser();
        public Task<User> GetUserById(Guid userId);

        public Task<Guid> CreateUser(User user);
        public Task<User> UpdateUser(User user);


        //public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByUserName(string userName);
    }
}
