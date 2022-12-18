using System.ComponentModel.DataAnnotations;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.Areas.Identity.Data.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace WebCarRentalSystem.ViewModels
{
    public class CreateContractViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DateContract { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter Date End")]
        [DataType(DataType.Date)]
        [FutureValidation]
        public DateTime DateEnd { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please choose a Car")]
        //[CarRentedValidation]
        public int CarId { get; set; }
        public Car? Car { get; set; }

        public string ApplicationUserId { get; set; }

        public IEnumerable<ModelCar>? ModelCar { get; set; }
        public Contract? Contract { get; set; }
    }
}
