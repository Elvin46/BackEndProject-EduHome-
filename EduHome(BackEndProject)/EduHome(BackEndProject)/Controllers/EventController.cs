using EduHome_BackEndProject_.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var events = await _dbContext.Events.ToListAsync();
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
    }
}
