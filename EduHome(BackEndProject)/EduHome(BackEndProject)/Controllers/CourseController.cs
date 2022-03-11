using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CourseController(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _dbContext.Courses.ToListAsync();
            return View(courses);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var existCourse = await _dbContext.Courses.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (existCourse == null)
            {
                return NotFound();
            }
            return View(existCourse);
        }
        public async Task<IActionResult> CategoryFilter(int? id)
        {

            var courses = await _dbContext.Courses.Where(x => x.CategoryId == id && !x.IsDeleted).ToListAsync();
            return View(courses);
        }
        public async Task<IActionResult> Search(string searchedText)
        {
            var courses = new List<Course>();
            if (searchedText==null)
            {
                courses = await _dbContext.Courses.ToListAsync();
            }
            else
            {
                courses = await _dbContext.Courses.Where(x => x.Name.ToLower().Contains(searchedText)).ToListAsync();
            }
            return PartialView("_SearchCoursePartial", courses);
        }
    }
}
