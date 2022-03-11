using System.ComponentModel.DataAnnotations;

namespace EduHome_BackEndProject_.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
}
