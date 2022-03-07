using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class Bio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Logo { get; set; }
        [StringLength(200)]
        public string FacebookUrl { get; set; }
        [StringLength(200)]
        public string PinterestUrl { get; set; }
        [StringLength(200)]
        public string LinkedinUrl { get; set; }
        [StringLength(200)]
        public string TwitterUrl { get; set; }

    }
}
