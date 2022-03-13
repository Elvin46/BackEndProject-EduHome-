using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _dbContext.Sliders.ToListAsync();
            var about = await _dbContext.Abouts.SingleOrDefaultAsync();
            var noticeSection = await _dbContext.NoticeSections.SingleOrDefaultAsync();
            var notices = await _dbContext.Notices.ToListAsync();
            var testimonials = await _dbContext.Testimonials.ToListAsync();
            var subscribe = await _dbContext.Subscribes.SingleOrDefaultAsync();
            var courses = await _dbContext.Courses.Where(x=>!x.IsDeleted).Take(3).ToListAsync();
            var coursesSection = await _dbContext.CoursesSections.SingleOrDefaultAsync();
            var events = await _dbContext.Events.Take(4).Where(x => !x.IsDeleted).ToListAsync();
            var blogs = await _dbContext.Blogs.Take(3).Where(x => !x.IsDeleted).ToListAsync();
            return View(new HomeViewModel
            {
                Sliders = sliders,
                About = about,
                NoticeSection = noticeSection,
                Notices = notices,
                Testimonials =testimonials,
                Subscribe = subscribe,
                Courses = courses,
                CoursesSection = coursesSection,
                Events = events,
                Blogs = blogs
            });
        }
    }
}
