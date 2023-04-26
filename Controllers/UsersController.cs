using LostAndFound.Data;
using LostAndFound.Data.Services;
using LostAndFound.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get Login view
        public IActionResult Login()
        {
            return View();
        }

        //Get:Actor/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Username,Password,Email,Contact")]User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await _service.AddAsync(user);
            return RedirectToAction(nameof(Index));
        }
        
        //Get User Details
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Get:Actor/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            return View(userDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FirstName,LastName,Username,Password,Email,Contact")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await _service.UpdateAsync(id,user);
            return RedirectToAction(nameof(Index));
        }
        //Delete an Actor
      
        public async Task<IActionResult> Delete(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            return View(userDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult>DeleteConfirmed(int id)
        {
            var userDetails = await _service.GetByIdAsync(id);
            if (userDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
