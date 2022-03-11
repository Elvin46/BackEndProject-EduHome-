using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EduHome_BackEndProject_.Models
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsSubscribed { get; set; }
        public int VerificationCode { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
