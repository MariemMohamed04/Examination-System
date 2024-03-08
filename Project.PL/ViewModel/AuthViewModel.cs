using System.ComponentModel.DataAnnotations;

namespace Project.PL.ViewModel
{
    public class AuthViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set;}
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Password { get; set;}

        [Required]
        [StringLength(6, MinimumLength = 6)]
        [Compare(nameof(Password), ErrorMessage = "Password Mismatch")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsAgree { get; set; }
    }
}
