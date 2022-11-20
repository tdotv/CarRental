using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCarRentalSystem.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string? Passport { get; set; }

        public string? DYears { get; set; }

        public decimal Rating { get; set; }

        [DisplayName("Home Addres")]
        public string? HomeAddres { get; set; }

        public decimal Telephone { get; set; }

    }
}
