using EduHome_BackEndProject_.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public List<Category> Categories { get; set; }
        public List<Teacher> Teachers { get; set; }
        public IFormFile Photo { get; set; }
        public List<EventsTeachers> SelectedEventsTeachers { get; set; }
        public List<int> TeachersId { get; set; }
    }
}
