using EduHome_BackEndProject_.Models;
using System.Collections.Generic;

namespace EduHome_BackEndProject_.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public About About { get; set; }
        public NoticeSection NoticeSection { get; set; }
        public List<Notice> Notices { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public Subscribe Subscribe { get; set; }
        public List<Course> Courses { get; set; }
        public CoursesSection CoursesSection { get; set; }
        public List<Event> Events { get; set; }
    }
}
