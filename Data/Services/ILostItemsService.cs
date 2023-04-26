using LostAndFound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Data.Services
{
   public interface ILostItemsService
    {
        Task<List<LostItem>> GetAllAsync();

        Task<LostItem> GetByIdAsync(int id);

        Task AddAsync(LostItem user);

        Task<LostItem> UpdateAsync(int id, LostItem newItem);

        Task DeleteAsync(int id);

    }
}
