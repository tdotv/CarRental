using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCarRentalSystem.Models
{
    public class ModelCar
    {
        [Key]
        public int Id { get; set; }

        public string? Class { get; set; }

        public string? Model { get; set; }

        public string? Marka { get; set; }

        public string? Image { get; set; }
    }
}
