using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_BackEndProject_.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Venue { get; set; }
        public DateTimeOffset? Created { get; set; } = DateTime.UtcNow;
        public ICollection<EventsTeachers> EventsTeachers { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
