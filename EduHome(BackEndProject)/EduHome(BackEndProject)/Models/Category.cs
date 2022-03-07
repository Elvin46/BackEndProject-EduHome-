using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
