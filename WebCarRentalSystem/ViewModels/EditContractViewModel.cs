using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.ViewModels
{
    public class EditContractViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DateContract { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        [Required]
        public int CarId { get; set; }
        public decimal ContractDays { get; set; }
        public decimal Price { get; set; }
    }
}
