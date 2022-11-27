using Microsoft.Build.Framework;

namespace WebCarRentalSystem.ViewModels.Car
{
    public class CreateCarViewModel
    {
        [Required]
        public int ModelCarId { get; set; }
        public string? Color { get; set; }
        public bool? Rented { get; set; }
        public string? CarRegNumber { get; set; }
    }
}
