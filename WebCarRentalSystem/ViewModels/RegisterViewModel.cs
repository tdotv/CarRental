using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email Address")]
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
