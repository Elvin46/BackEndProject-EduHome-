using EduHome_BackEndProject_.Areas.AdminPanel.Data;
using EduHome_BackEndProject_.Data;
using EduHome_BackEndProject_.DataAccessLayer;
using EduHome_BackEndProject_.Models;
using EduHome_BackEndProject_.ViewModels;
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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TeacherController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var teachers = await _dbContext.Teachers.Where(x => !x.IsDeleted).ToListAsync();

            return View(teachers);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (teacher == null)
            {
                return BadRequest();
            }
            var isExistTeacher = await _dbContext.Courses.AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == teacher.Name.ToLower());
            if (isExistTeacher)
            {
                ModelState.AddModelError("ExistTitle", "This course already exist");
                return View();
            }
            var maxSize = 1;
            if (teacher.Photo == null)
            {
                ModelState.AddModelError("", "Please Choose Photo");
                return View();
            }
            if (!teacher.Photo.IsImage())
            {
                ModelState.AddModelError("", "Upload Valid Images(png,jpg,jpeg)");
                return View();
            }
            if (!teacher.Photo.IsAllowedSize(maxSize))
            {
                ModelState.AddModelError("", $"This file is too large.Allowed maximum size is {maxSize}mb.");
                return View();
            }

            var fileName = await teacher.Photo.GenerateFile(Constants.ImageFolderPath, "teacher");
            teacher.Image = fileName;
            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Teacher existTeacher = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existTeacher == null)
                return Json(new { status = 404 });
            var path = Path.Combine(Constants.ImageFolderPath, "teacher", existTeacher.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            existTeacher.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Teacher existTeacher = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (existTeacher == null)
                return NotFound();

            return View(existTeacher);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Teacher isExistTeacher = _dbContext.Teachers.Where(x => x.IsDeleted == false).FirstOrDefault(x => x.Id == id);
            if (isExistTeacher == null)
                return NotFound();
            return View(isExistTeacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, TeacherViewModel teacherVM)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (id != teacherVM.Id)
            {
                return BadRequest();
            }
            var existTeacher = await _dbContext.Teachers.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (existTeacher == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(existTeacher);
            }
            var isExist = await _dbContext.Teachers.AnyAsync(x => x.IsDeleted == false && x.Name.ToLower() == teacherVM.Name.ToLower() && x.Id != teacherVM.Id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This teacher is already exist");
                return View(existTeacher);
            }
            if (teacherVM.Photo != null)
            {
                if (!teacherVM.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "It must be photo(jpg,png)");
                    return View(existTeacher);
                }
                if (!teacherVM.Photo.IsAllowedSize(1))
                {
                    ModelState.AddModelError("Photo", "Size of photo has to be under 1 mb");
                    return View(teacherVM);
                }
                var path = Path.Combine(Constants.ImageFolderPath, "blog", existTeacher.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                var fileName = await teacherVM.Photo.GenerateFile(Constants.ImageFolderPath, "course");
                existTeacher.Image = fileName;
            }
            existTeacher = new Teacher
            {
                Name = teacherVM.Name,
                Profession = teacherVM.Profession,
                About = teacherVM.About,
                Degree = teacherVM.Degree,
                Experience = teacherVM.Experience,
                Hobbies = teacherVM.Hobbies,
                Faculty = teacherVM.Faculty,
                Mail = teacherVM.Mail,
                PhoneNumber = teacherVM.PhoneNumber,
                Skype = teacherVM.Skype,
                FacebookUrl = teacherVM.FacebookUrl,
                PinterestUrl = teacherVM.PinterestUrl,
                LinkedinUrl = teacherVM.LinkedinUrl,
                TwitterUrl = teacherVM.TwitterUrl,
                LanguagePercent = teacherVM.LanguagePercent,
                TeamLeaderPercent = teacherVM.TeamLeaderPercent,
                DevelopmentPercent = teacherVM.DevelopmentPercent,
                DesignPercent = teacherVM.DesignPercent,
                InnovationPercent = teacherVM.InnovationPercent,
                CommunicationPercent = teacherVM.CommunicationPercent
            };
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
