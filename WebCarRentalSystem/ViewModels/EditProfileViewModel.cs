using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.ViewModels
{
    public class EditProfileViewModel
    {
        [Required(ErrorMessage = "Please enter Passport")]
        [RegularExpression(@"[A-Z]{2}[0-9]{7}", ErrorMessage = "The Passport field is not a valid")]
        public string? Passport { get; set; }

        [Range(1, 80)]
        [DisplayName("Drive Years")]
        public string? DYears { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(?:\+?1[-.●]?)?\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "The Telephone field is not a valid phone number")]
        public string? Telephone { get; set; }
    }
}
