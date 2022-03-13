using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _dbContext;

        public EventController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.PageCount = Math.Ceiling((decimal)_dbContext.Events.Count() / 6);
            ViewBag.CurrentPage = page;
            var events = await _dbContext.Events.Where(x=> !x.IsDeleted).Skip((page - 1) * 6).Take(6).ToListAsync();
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var existEvent = await _dbContext.Events.Include(x=>x.EventsTeachers).ThenInclude(x=> x.Teacher).FirstOrDefaultAsync(x=> x.Id == id);
            if (existEvent == null)
            {
                return NotFound();
            }

            return View(existEvent);
        }
        public async Task<IActionResult> CategoryFilter(int? id)
        {

            var events = await _dbContext.Events.Where(x => x.CategoryId == id && !x.IsDeleted).ToListAsync();
            return View(events);
        }
        public async Task<IActionResult> Search(string searchedText)
        {
            var events = new List<Event>();
            if (searchedText == null)
            {
                events = await _dbContext.Events.ToListAsync();
            }
            else
            {
                events = await _dbContext.Events.Where(x => x.Title.ToLower().Contains(searchedText)).ToListAsync();
            }
            return PartialView("_SearchEventPartial", events);
        }
    }
}
