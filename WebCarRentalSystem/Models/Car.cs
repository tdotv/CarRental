using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCarRentalSystem.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ModelCar")]
        [DisplayName("Model")]
        public int ModelCarId { get; set; }
        public ModelCar? Model { get; set; }

        public string? Color { get; set; }

        public bool Rented { get; set; }
        [DisplayName("Registration Number")]
        public string? CarRegNumber { get; set; }
    }
}
