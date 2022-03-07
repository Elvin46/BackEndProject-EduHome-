using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Subtitle { get; set; }
        [Required]
        [StringLength(100)]
        public string Image { get; set; }
    }
}
