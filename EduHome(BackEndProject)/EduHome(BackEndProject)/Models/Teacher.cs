using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_BackEndProject_.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Profession { get; set; }
        [StringLength(50)]
        public string Image { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        [StringLength(1000)]
        public string About { get; set; }
        [Required]
        [StringLength(50)]
        public string Degree { get; set; }
        [Required]
        [StringLength(50)]
        public string Experience { get; set; }
        [Required]
        [StringLength(50)]
        public string Hobbies { get; set; }
        [Required]
        [StringLength(50)]
        public string Faculty { get; set; }
        [Required]
        [StringLength(50)]
        public string Mail { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Skype { get; set; }
        [StringLength(200)]
        public string FacebookUrl { get; set; } = "https://www.facebook.com/";
        [StringLength(200)]
        public string PinterestUrl { get; set; } = "https://www.Pinterest.com/";
        [StringLength(200)]
        public string LinkedinUrl { get; set; } = "https://www.linkedin.com/";
        [StringLength(200)]
        public string TwitterUrl { get; set; } = "https://twitter.com/";
        [Required]
        public int LanguagePercent { get; set; }
        [Required]
        public int TeamLeaderPercent { get; set; }
        [Required]
        public int DevelopmentPercent { get; set; }
        [Required]
        public int DesignPercent { get; set; }
        [Required]
        public int InnovationPercent { get; set; }
        [Required]
        public int CommunicationPercent { get; set; }
        public ICollection<EventsTeachers> EventsTeachers { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
