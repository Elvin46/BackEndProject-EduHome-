using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class Subscribe
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Subtitle { get; set; }

    }
}
