using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.ViewModels
{
    public class CreateCarViewModel
    {
        [Required]
        public int ModelCarId { get; set; }
        public string Color { get; set; }
        public bool Rented { get; set; }

        [RegularExpression(@"^[A-Z]{2}[0-9]{2}[A-Z]{2}[0-9]{4}$", ErrorMessage = "The Car Registration Number field is not valid")]
        [DisplayName("Registration Number")]
        public string CarRegNumber { get; set; }
        //public IEnumerable<ModelCar> Models { get; set; }
    }
}
