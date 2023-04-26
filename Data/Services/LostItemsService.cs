using LostAndFound.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Data.Services
{
  public class LostItemsService : ILostItemsService
    {
        private readonly AppDbContext _context;
        public LostItemsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(LostItem item)
        {
            await _context.LostItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.LostItems.FirstOrDefaultAsync(n => n.Id == id);
            _context.LostItems.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LostItem>> GetAllAsync()
        {
            var result = await _context.LostItems.ToListAsync();
            return result;
        }

        public async Task<LostItem> GetByIdAsync(int id)
        {
            var result = await _context.LostItems.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<LostItem> UpdateAsync(int id, LostItem newItem)
        {
            _context.Update(newItem);
            await _context.SaveChangesAsync();
            return newItem;

        }
    }
}
