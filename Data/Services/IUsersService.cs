using LostAndFound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Data.Services
{
   public interface IUsersService
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task AddAsync(User user);

        Task<User> UpdateAsync(int id, User newUser);

        Task DeleteAsync(int id);
    }
}
