using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCarRentalSystem.ViewModels
{
    public class EditAccidentViewModel
    {
        [ForeignKey("Contract")]
        [Required(ErrorMessage = "Please Enter Contract Id")]
        public int ContractId { get; set; }

        [Required(ErrorMessage = "Please enter Dtp Date")]
        [DataType(DataType.Date)]
        [DisplayName("Dtp Date")]
        public DateTime DateDtp { get; set; }

        [Required(ErrorMessage = "Please enter Collisions")]
        public string Collisions { get; set; }

        [Required(ErrorMessage = "Please enter Result")]
        [Range(0, double.MaxValue)]
        public decimal Result { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateDtp < DateTime.Now)
            {
                yield return new ValidationResult("Date is incorrect");
            }
        }
    }
}
