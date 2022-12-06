using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.ViewModels
{
    public class CreateContractViewModel : IValidatableObject
    {
        [DataType(DataType.Date)]
        public DateTime DateContract { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter Date End")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        [Required(ErrorMessage = "Please enter Car ID")]
        public int CarId { get; set; }

        public string ApplicationUserId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateEnd <= DateContract)
            {
                yield return new ValidationResult("Date is incorrect");
            }
        }
    }
}
