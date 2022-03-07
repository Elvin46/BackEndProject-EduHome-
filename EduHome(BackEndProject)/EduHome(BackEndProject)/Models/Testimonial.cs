using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorName { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorField { get; set; }
        [Required]
        [StringLength(200)]
        public string Text { get; set; }
        [Required]
        [StringLength(100)]
        public string Image { get; set; }
    }
}
