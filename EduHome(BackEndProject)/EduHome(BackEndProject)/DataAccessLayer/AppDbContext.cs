using EduHome_BackEndProject_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHome_BackEndProject_.DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<User>   
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<NoticeSection> NoticeSections { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CoursesSection> CoursesSections { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<EventsTeachers> EventsTeachers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
