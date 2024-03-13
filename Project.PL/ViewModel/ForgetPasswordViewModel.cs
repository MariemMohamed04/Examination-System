using System.ComponentModel.DataAnnotations;

namespace Project.PL.ViewModel
{
    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
