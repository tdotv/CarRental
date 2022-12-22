using System.ComponentModel.DataAnnotations;
using WebCarRentalSystem.Areas.Identity.Data.DataAnnotations;

namespace WebCarRentalSystem.ViewModels
{
    public class EditContractViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DateContract { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [FutureValidation]
        public DateTime DateEnd { get; set; } = DateTime.Now;
        [Required]
        public int CarId { get; set; }
        [Range(0, 90)]
        public decimal ContractDays { get; set; }
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
