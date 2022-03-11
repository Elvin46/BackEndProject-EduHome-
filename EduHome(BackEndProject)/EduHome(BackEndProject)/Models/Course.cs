using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_BackEndProject_.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Image { get; set; }
        [Required]
        [StringLength(1000)]
        public string AboutCourse { get; set; }
        [Required]
        [StringLength(1000)]
        public string HowToApply { get; set; }
        [Required]
        [StringLength(1000)]
        public string Certification { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int ClassDuration { get; set; }
        [Required]
        [StringLength(50)]
        public string SkillLevel { get; set; }
        [Required]
        [StringLength(50)]
        public string Language { get; set; }
        [Required]
        public int StudentsCount { get; set; }
        [Required]
        [StringLength(50)]
        public string Assesments { get; set; }
        [Required]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; } = false;
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
