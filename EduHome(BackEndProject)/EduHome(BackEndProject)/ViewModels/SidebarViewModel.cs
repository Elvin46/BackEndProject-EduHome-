using EduHome_BackEndProject_.Models;
using System.Collections.Generic;

namespace EduHome_BackEndProject_.ViewModels
{
    public class SidebarViewModel
    {
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }
    }
}
