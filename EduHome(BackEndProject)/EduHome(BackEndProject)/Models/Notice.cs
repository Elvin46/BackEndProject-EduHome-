using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.Models
{
    public class Notice
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishDate { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
