using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(400)]
        public string SectionText { get; set; }
        [Required]
        [StringLength(400)]
        public string SectionText2 { get; set; }
        [Required]
        [StringLength(150)]
        public string Image { get; set; }
    }
}
