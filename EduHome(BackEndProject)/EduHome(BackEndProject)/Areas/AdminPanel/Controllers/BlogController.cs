using EduHome_BackEndProject_.Areas.AdminPanel.Data;
using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome_BackEndProject_.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _dbContext.Blogs.Include(x=> x.Category).Where(x => !x.IsDeleted).ToListAsync();

            return View(blogs);
        }
        public async Task<IActionResult> Create()
        {
            var Categories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            ViewBag.Categories = Categories;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog,int CategoryId)
        {
            var Categories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            ViewBag.Categories = Categories;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (blog == null)
            {
                return BadRequest();
            }
            var isExistBlog = await _dbContext.Blogs.AnyAsync(x => x.IsDeleted == false && x.Title.ToLower() == blog.Title.ToLower());
            if (isExistBlog)
            {
                ModelState.AddModelError("ExistTitle", "This blog already exist");
                return View();
            }
            var maxSize = 1;
            if (blog.Photo == null)
            {
                ModelState.AddModelError("", "Please Choose Photo");
                return View();
            }
            if (!blog.Photo.IsImage())
            {
                ModelState.AddModelError("", "Upload Valid Images(png,jpg,jpeg)");
                return View();
            }
            if (!blog.Photo.IsAllowedSize(maxSize))
            {
                ModelState.AddModelError("", $"This file is too large.Allowed maximum size is {maxSize}mb.");
                return View();
            }

            var fileName = await blog.Photo.GenerateFile(Constants.ImageFolderPath, "blog");
            blog.Image = fileName;
            blog.CategoryId = CategoryId;
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Blog existBlog = await _dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existBlog == null)
                return Json(new { status = 404 });
            var path = Path.Combine(Constants.ImageFolderPath, "blog" ,existBlog.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _dbContext.Blogs.Remove(existBlog);
            await _dbContext.SaveChangesAsync();
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Blog existBlog = await _dbContext.Blogs.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existBlog == null)
                return NotFound();

            return View(existBlog);
        }
        public async Task<IActionResult> Update(int? id)
        {
            var Categories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            ViewBag.Categories = Categories;
            if (id == null)
            {
                return BadRequest();
            }
            Blog isExistBlog = _dbContext.Blogs.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.Id == id);
            if (isExistBlog == null)
                return NotFound();
            return View(isExistBlog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, BlogViewModel blogVM, int CategoryId)
        {
            var Categories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            ViewBag.Categories = Categories;
            if (id == null)
            {
                return BadRequest();
            }
            if (id != blogVM.Id)
            {
                return BadRequest();
            }
            var existBlog = await _dbContext.Blogs.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existBlog == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(existBlog);
            }
            var isExist = await _dbContext.Blogs.AnyAsync(x => x.IsDeleted == false && x.Title.ToLower() == blogVM.Title.ToLower() && x.Id != blogVM.Id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This blog is already exist");
                return View(existBlog);
            }
            if (blogVM.Photo != null)
            {
                if (!blogVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "It must be photo(jpg,png)");
                    return View(existBlog);
                }
                if (!blogVM.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "Size of photo has to be under 1 mb");
                    return View(blogVM);
                }
                var path = Path.Combine(Constants.ImageFolderPath, "blog", existBlog.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await blogVM.Photo.GenerateFile(Constants.ImageFolderPath, "blog");
                existBlog.Image = fileName;
            }
            existBlog.CategoryId = CategoryId;
            existBlog = new Blog
            {
                Title = blogVM.Title,
                ByWho = blogVM.ByWho,
                Description = blogVM.Description
            };
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
