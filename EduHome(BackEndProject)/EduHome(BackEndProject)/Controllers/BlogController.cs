using EduHome_BackEndProject_.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _dbContext.Blogs.ToListAsync();
            blogs.OrderBy(x => x.Created);
            blogs.Reverse();
            if (blogs == null)
            {
                return NotFound();
            }
            return View(blogs);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var existBlog = await _dbContext.Blogs.FirstOrDefaultAsync(x=> !x.IsDeleted && x.Id == id);
            if (existBlog == null)
            {
                return NotFound();
            }
            return View(existBlog);
        }
    }
}
