using Microsoft.Build.Framework;

namespace WebCarRentalSystem.ViewModels.Accident
{
    public class CreateAccidentViewModel
    {
        [Required]
        public int ContractId { get; set; }
        public DateTime DateDtp { get; set; }
        public string? Collisions { get; set; }
        public decimal? Result { get; set; }
    }
}
