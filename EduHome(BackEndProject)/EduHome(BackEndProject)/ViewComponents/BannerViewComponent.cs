using EduHome_BackEndProject_.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        public BannerViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
