using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome_BackEndProject_.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Image { get; set; }
        [Required]
        [StringLength(50)]
        public string ByWho { get; set; }
        public DateTimeOffset? Created { get; set; } = DateTime.UtcNow;
        public int Comment { get; set; } = 0;
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; } = false;
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
