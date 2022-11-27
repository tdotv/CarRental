using System.ComponentModel;
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

        [Required]
        public string Image { get; set; }

        public string? Description { get; set;}

        [DisplayName("Fuel Consumption")]
        public decimal? FuelConsumption { get; set; }

        public string? Transmission { get; set; }

        [DisplayName("Engine Value")]
        public decimal? EngineValue { get; set; }

        [DisplayName("Manufacture Year")]
        public string? ManufactureYear { get; set; }
    }
}
