using EduHome_BackEndProject_.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_BackEndProject_.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
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
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
