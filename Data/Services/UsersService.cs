using LostAndFound.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Data.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
           await _context.Users.AddAsync(user);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<User> UpdateAsync(int id, User newUser)
        {
           _context.Update(newUser);
           await _context.SaveChangesAsync();
           return newUser;

        }
    }
}
