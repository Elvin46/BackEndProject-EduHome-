using EduHome_BackEndProject_.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Views.Shared
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public FooterViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bio = await _dbContext.Bios.SingleOrDefaultAsync();

            return View(bio);
        }
    }
}
