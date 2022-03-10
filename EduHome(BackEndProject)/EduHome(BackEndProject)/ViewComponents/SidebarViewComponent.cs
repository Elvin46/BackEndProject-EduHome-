using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var blogs = await _dbContext.Blogs.OrderByDescending(x=> x.Created).Take(count).ToListAsync();
            var categories = await _dbContext.Categories.ToListAsync();
            return View(new SidebarViewModel
            {
                Blogs = blogs,
                Categories = categories
            });
        }
    }
}
