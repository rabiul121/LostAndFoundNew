using LostAndFound.Data;
using LostAndFound.Data.Services;
using LostAndFound.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace LostAndFound.Controllers
{
    public class LostItemsController : Controller
    {
        private readonly ILostItemsService _service;
        public LostItemsController(ILostItemsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Creating a new item
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PhotoURL,ItemName,Category,Description,LostArea,Date")] LostItem item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            await _service.AddAsync(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
