using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class NoticeSection
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string VideoTitle { get; set; }
        [Required]
        public string VideoUrl { get; set; }

    }
}
