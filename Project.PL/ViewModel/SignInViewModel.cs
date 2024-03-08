using System.ComponentModel.DataAnnotations;

namespace Project.PL.ViewModel
{
    public class SignInViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
