using LostAndFound.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Controllers
{
    public class FoundItemsController : Controller
    {
        private AppDbContext _context;

        public FoundItemsController(AppDbContext context)
        {
            _context = context;
        }
        public  async Task<IActionResult> Index()
        {
            var data = await _context.FoundItems.ToListAsync();
            return View(data);
        }
    }
}
