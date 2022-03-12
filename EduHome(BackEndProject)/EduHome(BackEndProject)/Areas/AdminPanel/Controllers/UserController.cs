using EduHome_BackEndProject_.Data;
using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(AppDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _dbContext.Users.ToListAsync();
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                UserViewModel userVM = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()?? "doesn't have role"
                };
                userViewModels.Add(userVM);
            }
            return View(userViewModels);
        }

        public async Task<IActionResult> Activate(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            if (user.IsActive == true)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeRole(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            string currentRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (currentRole == null)
            {
                return NotFound();
            }
            var courses = await _dbContext.Courses.Where(x=>!x.IsDeleted && x.UserId == null).ToListAsync();
            if (courses == null)
                return NotFound();
            var selectedCourses = await _dbContext.Courses.Where(x => !x.IsDeleted && x.UserId == id).ToListAsync();
            var roles = await _roleManager.Roles.ToListAsync();
            return View(new UserSystemViewModel
            {
                CurrenRole = currentRole,
                Roles = roles,
                Courses = courses,
                SelectedCourses = selectedCourses,
                User = user
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(string? id, string changedRole,UserSystemViewModel userSystemVM)
        {
            if (id == null || changedRole == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            string latestRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if (latestRole == null)
            {
                return BadRequest();
            }
            if (latestRole != changedRole)
            {
                var deleteRole = await _userManager.RemoveFromRoleAsync(user, latestRole);
                if (!deleteRole.Succeeded)
                {
                    ModelState.AddModelError("", "Problems Found");
                    return View();
                }
                var result = await _userManager.AddToRoleAsync(user, changedRole);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Problems Found");
                    return View();
                }
                await _userManager.UpdateAsync(user);
            }
            if (user.Courses == null)
            {
                user.Courses = new List<Course>();
            }
            if (changedRole == RoleConstants.ModeratorRole)
            {
                var courses = await _dbContext.Courses.Where(x=>!x.IsDeleted && x.UserId == user.Id).ToListAsync();
                foreach (var item in courses)
                {
                    user.Courses.Remove(item);
                }
                foreach (var courseId in userSystemVM.CourseId)
                {
                    var course = await _dbContext.Courses.Where(x => x.Id == courseId).FirstOrDefaultAsync();

                    user.Courses.Add(course);
                }
            }
            else
            {
                var courses = await _dbContext.Courses.Where(x => !x.IsDeleted && x.UserId == user.Id).ToListAsync();
                foreach (var item in courses)
                {
                    user.Courses.Remove(item);
                }
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ChangePassword(string? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(changePasswordVM);
            }
            var user = await _userManager.FindByIdAsync(changePasswordVM.Id);
            if (user == null)
            {
                return BadRequest();
            }
            var checkPassword = await _userManager.CheckPasswordAsync(user, changePasswordVM.OldPassword);
            if (checkPassword == false)
            {
                ModelState.AddModelError("OldPassword", "Invalid Password");
                return View(changePasswordVM);
            }
            var result = await _userManager.ChangePasswordAsync(user, changePasswordVM.OldPassword, changePasswordVM.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View(changePasswordVM);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
