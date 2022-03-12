using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Controllers
{
    public class GlobalSearchController : Controller
    {
        private readonly AppDbContext _dbContext;

        public GlobalSearchController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Search(string searchedText)
        {
            var blogs = await _dbContext.Blogs.Where(x => !x.IsDeleted && x.Title.ToLower().Contains(searchedText.ToLower().Trim())).ToListAsync();
            var courses = await _dbContext.Courses.Where(x => !x.IsDeleted && x.Name.ToLower().Contains(searchedText.ToLower().Trim())).ToListAsync();
            var events = await _dbContext.Events.Where(x => !x.IsDeleted && x.Title.ToLower().Contains(searchedText.ToLower().Trim())).ToListAsync();
            var teachers = await _dbContext.Teachers.Where(x => !x.IsDeleted && x.Name.ToLower().Contains(searchedText.ToLower().Trim())).ToListAsync();

            return PartialView("_GlobalSearchPartial", new GlobalSearchViewModel
            {
                Blogs = blogs,
                Courses = courses,
                Events = events,
                Teachers = teachers
            });
        }
    }
}
