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
    public class CourseController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CourseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _dbContext.Courses.Include(x => x.Category).Where(x => !x.IsDeleted).ToListAsync();

            return View(courses);
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
        public async Task<IActionResult> Create(Course course, int CategoryId)
        {
            var Categories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            ViewBag.Categories = Categories;
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (course == null)
            {
                return BadRequest();
            }
            var isExistBlog = await _dbContext.Courses.AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == course.Name.ToLower());
            if (isExistBlog)
            {
                ModelState.AddModelError("ExistTitle", "This course already exist");
                return View();
            }
            var maxSize = 1;
            if (course.Photo == null)
            {
                ModelState.AddModelError("", "Please Choose Photo");
                return View();
            }
            if (!course.Photo.IsImage())
            {
                ModelState.AddModelError("", "Upload Valid Images(png,jpg,jpeg)");
                return View();
            }
            if (!course.Photo.IsAllowedSize(maxSize))
            {
                ModelState.AddModelError("", $"This file is too large.Allowed maximum size is {maxSize}mb.");
                return View();
            }

            var fileName = await course.Photo.GenerateFile(Constants.ImageFolderPath, "course");
            course.Image = fileName;
            course.CategoryId = CategoryId;
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Course existCourse = await _dbContext.Courses.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existCourse == null)
                return Json(new { status = 404 });
            var path = Path.Combine(Constants.ImageFolderPath, "course", existCourse.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            existCourse.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Course existCourse = await _dbContext.Courses.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existCourse == null)
                return NotFound();

            return View(existCourse);
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
            Course isExistCourse = _dbContext.Courses.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.Id == id);
            if (isExistCourse == null)
                return NotFound();
            return View(isExistCourse);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CourseViewModel courseVM, int CategoryId)
        {
            var Categories = await _dbContext.Categories
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
            ViewBag.Categories = Categories;
            if (id == null)
            {
                return BadRequest();
            }
            if (id != courseVM.Id)
            {
                return BadRequest();
            }
            var existCourse = await _dbContext.Courses.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existCourse == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(existCourse);
            }
            var isExist = await _dbContext.Courses.AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == courseVM.Name.ToLower() && x.Id != courseVM.Id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This course is already exist");
                return View(existCourse);
            }
            if (courseVM.Photo != null)
            {
                if (!courseVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "It must be photo(jpg,png)");
                    return View(existCourse);
                }
                if (!courseVM.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "Size of photo has to be under 1 mb");
                    return View(courseVM);
                }
                var path = Path.Combine(Constants.ImageFolderPath, "blog", existCourse.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await courseVM.Photo.GenerateFile(Constants.ImageFolderPath, "course");
                existCourse.Image = fileName;
            }
            existCourse.CategoryId = CategoryId;
            existCourse = new Course
            {
                Name = courseVM.Name,
                Description = courseVM.Description,
                AboutCourse = courseVM.AboutCourse,
                HowToApply = courseVM.HowToApply,
                Certification = courseVM.Certification,
                StartDate = courseVM.StartDate,
                Duration = courseVM.Duration,
                ClassDuration = courseVM.ClassDuration,
                SkillLevel = courseVM.SkillLevel,
                Language = courseVM.Language,
                StudentsCount = courseVM.StudentsCount,
                Assesments = courseVM.Assesments,
                Price = courseVM.Price
            };
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

