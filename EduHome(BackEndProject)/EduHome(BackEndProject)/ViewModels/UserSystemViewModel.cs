using EduHome_BackEndProject_.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EduHome_BackEndProject_.ViewModels
{
    public class UserSystemViewModel
    {
        public User User { get; set; }
        public string CurrenRole { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<Course> Courses { get; set; }
        public List<Course> SelectedCourses { get; set; }
        public List<Course> SelectedByOtherUsers { get; set; }
        public List<int> CourseId { get; set; }

    }
}
