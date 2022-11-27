using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.ViewModels.Administraion
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
