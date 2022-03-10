using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public SidebarViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _dbContext.Blogs.ToListAsync();
            var categories = await _dbContext.Categories.ToListAsync();
            blogs.OrderBy(x=> x.Created);
            blogs.Reverse();
            blogs.Take(3);
            return View(new SidebarViewModel
            {
                Blogs = blogs,
                Categories = categories
            });
        }
    }
}
