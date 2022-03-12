using EduHome_BackEndProject_.Models;
using System.Collections.Generic;

namespace EduHome_BackEndProject_.ViewModels
{
    public class GlobalSearchViewModel
    {
        public List<Blog> Blogs { get; set; }
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Event> Events { get; set; }
    }
}
