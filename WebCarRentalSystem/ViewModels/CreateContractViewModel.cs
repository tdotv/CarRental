using Microsoft.Build.Framework;

namespace WebCarRentalSystem.ViewModels
{
    public class CreateContractViewModel
    {
        public int Id { get; set; }
        public DateTime DateContract { get; set; }
        public DateTime DateEnd { get; set; }
        [Required]
        public int CarId { get; set; }
        public decimal ContractDays { get; set; }
        public decimal Price { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
