using Azure.Core;
using ElAlAIR.DataAccess.DataContext;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DataAccess.Interfaces;
using ElAlAIR.DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ElalDbContext _elalContext;

        public UserRepository(ElalDbContext elalContext)
        {
            _elalContext = elalContext;
        }
        
        
        public async Task<Guid> CreateUser(User user)
        {
            try
            {
                await _elalContext.Users.AddAsync(user);
                await _elalContext.SaveChangesAsync();
                return user.UserId;

                // _elalContext.Users.AddAsync(user);
                // _elalContext.SaveChangesAsync();
                //return user;
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public async Task<List<User>> GetUser()
        {
            try
            {
                return await _elalContext.Users.ToListAsync();
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<User> GetUserById(Guid userId)
        {
            try
            {

                return _elalContext.Users.FirstOrDefault(u => u.UserId == userId);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        //public async Task<User> GetUserByEmail(string email)
        //{
        //    try
        //    {
        //        return _elalContext.Users.FirstOrDefault(u => u.Email == email);
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Unexpected error creating order: {ex.Message}");
        //        throw new ApplicationException("Error creating order", ex);
        //    }
        //}

        public async Task<User> GetUserByUserName(string userName)
        {
            try
            {
                return await _elalContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                _elalContext.Users.Entry(user).State = EntityState.Modified;
                //_elalContext.SaveChanges();
                await _elalContext.SaveChangesAsync();
                return user;
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            } 
        }
    }
}
