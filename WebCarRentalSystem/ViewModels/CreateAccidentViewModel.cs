using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCarRentalSystem.ViewModels
{
    public class CreateAccidentViewModel
    {
        [ForeignKey("Contract")]
        [Required(ErrorMessage = "Please Enter Contract Id")]
        public int ContractId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateDtp { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter Collisions")]
        public string Collisions { get; set; }

        [Required(ErrorMessage = "Please enter Result")]
        [Range(0, double.MaxValue)]
        public decimal Result { get; set; }
    }
}
