using System.ComponentModel.DataAnnotations;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.Areas.Identity.Data.DataAnnotations;

namespace WebCarRentalSystem.ViewModels
{
    public class CreateContractViewModel
    {
        [DataType(DataType.Date)]
        public DateTime DateContract { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter Date End")]
        [DataType(DataType.Date)]
        [FutureValidation]
        public DateTime DateEnd { get; set; }

        [Required(ErrorMessage = "Please enter Car ID")]
        public int CarId { get; set; }

        public string ApplicationUserId { get; set; }

        public IEnumerable<ModelCar>? ModelCar { get; set; }
        public Contract? Contract { get; set; }


    }
}
