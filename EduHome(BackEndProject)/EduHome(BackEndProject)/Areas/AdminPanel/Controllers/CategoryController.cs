using EduHome_BackEndProject_.Areas.AdminPanel.Data;
using EduHome_BackEndProject_.Data;
using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            return View(categories);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category existCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existCategory == null)
                return Json(new { status = 404 });

            _dbContext.Categories.Remove(existCategory);
            _dbContext.SaveChanges();
            return Json(new { status = 200 });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (category == null)
            {
                return BadRequest();
            }
            var isExistCategory = await _dbContext.Categories.AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == category.Name.ToLower());
            if (isExistCategory)
            {
                ModelState.AddModelError("ExistTitle", "This category already exist");
                return View();
            }
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category isExistCategory = _dbContext.Categories.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.Id == id);
            if (isExistCategory == null)
                return NotFound();
            return View(isExistCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (id != category.Id)
            {
                return BadRequest();
            }
            var existCategory = await _dbContext.Categories.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existCategory == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(existCategory);
            }
            var isExist = await _dbContext.Categories.AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == category.Name.ToLower() && x.Id != category.Id);
            if (isExist)
            {
                ModelState.AddModelError("Fullname", "This category is already exist");
                return View(existCategory);
            }

            existCategory.Name = category.Name;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
