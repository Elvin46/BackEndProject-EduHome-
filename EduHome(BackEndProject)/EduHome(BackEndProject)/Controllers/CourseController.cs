using EduHome_BackEndProject_.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public CourseController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _dbcontext.Courses.ToListAsync();
            return View(courses);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var existCourse = await _dbcontext.Courses.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id);
            if (existCourse == null)
            {
                return NotFound();
            }
            return View(existCourse);
        }
    }
}
