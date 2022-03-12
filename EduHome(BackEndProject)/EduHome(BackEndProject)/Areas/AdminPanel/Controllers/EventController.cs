using EduHome_BackEndProject_.Areas.AdminPanel.Data;
using EduHome_BackEndProject_.Data;
using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class EventController : Controller
    {
        private readonly AppDbContext _dbContext;

        public EventController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _dbContext.Events.Where(x => !x.IsDeleted).ToListAsync();

            return View(events);
        }
        public async Task<IActionResult> Create()
        {
            EventViewModel eventVM = new EventViewModel
            {
                Categories = await _dbContext.Categories.Where(x => !x.IsDeleted).ToListAsync(),
                Teachers = await _dbContext.Teachers.Where(x => !x.IsDeleted).ToListAsync(),
            };
            return View(eventVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventVM)
        {
            eventVM.Categories = await _dbContext.Categories.Where(x => !x.IsDeleted).ToListAsync();
            eventVM.Teachers = await _dbContext.Teachers.Where(x => !x.IsDeleted).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(eventVM);
            }
            if (eventVM == null)
            {
                return BadRequest();
            }
            var isExistEvent = await _dbContext.Events.AnyAsync(x => x.IsDeleted == false && x.Title.ToLower() == eventVM.Event.Title.ToLower());
            if (isExistEvent)
            {
                ModelState.AddModelError("ExistTitle", "This event already exist");
                return View();
            }
            var maxSize = 1;
            if (eventVM.Photo == null)
            {
                ModelState.AddModelError("", "Please Choose Photo");
                return View();
            }
            if (!eventVM.Photo.IsImage())
            {
                ModelState.AddModelError("", "Upload Valid Images(png,jpg,jpeg)");
                return View();
            }
            if (!eventVM.Photo.IsAllowedSize(maxSize))
            {
                ModelState.AddModelError("", $"This file is too large.Allowed maximum size is {maxSize}mb.");
                return View();
            }

            var fileName = await eventVM.Photo.GenerateFile(Constants.ImageFolderPath, "event");
            eventVM.Event.Image = fileName;
            eventVM.Event.EventsTeachers = new List<EventsTeachers>();
            foreach (var teacher in eventVM.TeachersId)
            {
                EventsTeachers eventsTeachers = new EventsTeachers
                {
                    Event = eventVM.Event,
                    TeacherId = teacher
                };
                eventVM.Event.EventsTeachers.Add(eventsTeachers);
            }
            await _dbContext.Events.AddAsync(eventVM.Event);
            await _dbContext.SaveChangesAsync();
            var existEvent = await _dbContext.Events
                .Where(x => x.IsDeleted == false && x.Title.ToLower() == eventVM.Event.Title.ToLower())
                .FirstOrDefaultAsync();
            //string link = Url.Action(nameof(Detail), "Event", new { id = existEvent.Id }, Request.Scheme, Request.Host.ToString());
            string link = "https://localhost:44380/Event/Details/"+existEvent.Id.ToString();

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("codep320@gmail.com", "EduHome");
            var users = await _dbContext.Users.Where(x => x.IsSubscribed).ToListAsync();
            foreach (var user in users)
            {
                msg.To.Add(user.Email);
            }


            msg.Body = $"<a href=\"{link}\">We have new Event.You can see details with this link.</a>";
            msg.Subject = "New event created.You should look at this.";
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("codep320@gmail.com", "codeacademyp320");
            smtp.Send(msg);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Event existEvent = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existEvent == null)
                return Json(new { status = 404 });
            var path = Path.Combine(Constants.ImageFolderPath, "event", existEvent.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            existEvent.IsDeleted = true;
            var eventsTeachers = await _dbContext.EventsTeachers.Where(x => x.EventId == id).ToListAsync();
            foreach (var item in eventsTeachers)
            {
                item.IsDeleted = true;
            }
            await _dbContext.SaveChangesAsync();
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Event existEvent = await _dbContext.Events.Include(x => x.Category).Include(x=> x.EventsTeachers).ThenInclude(x=> x.Teacher).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existEvent == null)
                return NotFound();

            return View(existEvent);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            EventViewModel eventVM = new EventViewModel
            {
                Categories = await _dbContext.Categories.Where(x => !x.IsDeleted).ToListAsync(),
                Teachers = await _dbContext.Teachers.Where(x => !x.IsDeleted).ToListAsync(),
                Event = await _dbContext.Events.Where(x => x.Id == id).FirstOrDefaultAsync(),
                SelectedEventsTeachers = await _dbContext.EventsTeachers.Where(x => !x.IsDeleted && x.EventId == id).ToListAsync()
            };
            return View(eventVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,EventViewModel eventVM)
        {
            if (id == null)
            {
                return BadRequest();
            }
            eventVM.Categories = await _dbContext.Categories.Where(x => !x.IsDeleted).ToListAsync();
            eventVM.Teachers = await _dbContext.Teachers.Where(x => !x.IsDeleted).ToListAsync();
            eventVM.Event = await _dbContext.Events.Where(x => x.Id == id).FirstOrDefaultAsync();
            eventVM.SelectedEventsTeachers = await _dbContext.EventsTeachers.Where(x => !x.IsDeleted && x.EventId == id).ToListAsync();
            var existEvent = await _dbContext.Events.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existEvent == null)
            {
                return NotFound();
            }
            if (id != existEvent.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(eventVM);
            }
            var isExistEvent = await _dbContext.Events.AnyAsync(x => x.IsDeleted == false && x.Title.ToLower() == eventVM.Event.Title.ToLower() && x.Id != id);
            if (isExistEvent)
            {
                ModelState.AddModelError("Title", "This event is already exist");
                return View(eventVM);
            }
            if (eventVM.Photo != null)
            {
                if (!eventVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "It must be photo(jpg,png)");
                    return View(eventVM);
                }
                if (!eventVM.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "Size of photo has to be under 1 mb");
                    return View(eventVM);
                }
                var path = Path.Combine(Constants.ImageFolderPath, "event", existEvent.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await eventVM.Photo.GenerateFile(Constants.ImageFolderPath, "event");
                existEvent.Image = fileName;
            }
            existEvent.Title = eventVM.Event.Title;
            existEvent.Text = eventVM.Event.Text;
            existEvent.Time = eventVM.Event.Time;
            existEvent.Venue = eventVM.Event.Venue;
            existEvent.CategoryId = eventVM.Event.CategoryId;
            existEvent.EventsTeachers = new List<EventsTeachers>();
            var removedEventsTeachers = new List<EventsTeachers>();
            foreach (var teacherId in eventVM.TeachersId)
            {
                EventsTeachers eventsTeachers = new EventsTeachers
                {
                    Event = eventVM.Event,
                    TeacherId = teacherId,
                    EventId = eventVM.Event.Id
                };
                existEvent.EventsTeachers.Add(eventsTeachers);
                removedEventsTeachers = await _dbContext.EventsTeachers.Where(x => x.TeacherId != teacherId && x.EventId == eventVM.Event.Id).ToListAsync();
            }
            foreach (var item in removedEventsTeachers)
            {
                _dbContext.EventsTeachers.Remove(item);
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
