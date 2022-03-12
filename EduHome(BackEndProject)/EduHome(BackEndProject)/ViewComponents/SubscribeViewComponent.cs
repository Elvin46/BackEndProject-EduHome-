using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.ViewComponents
{
    public class SubscribeViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public SubscribeViewComponent(AppDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var subscribe = await _dbContext.Subscribes.SingleOrDefaultAsync();
            var username =User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            return View(new SubscribeViewModel
            {
                Subscribe = subscribe,
                User = user
            });
        }
    }
}
