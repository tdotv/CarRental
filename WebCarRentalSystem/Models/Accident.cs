using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCarRentalSystem.Models
{
    public class Accident
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Contract")]
        [DisplayName("Contract")]
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }

        [DisplayName("Dtp Date")]
        public DateTime DateDtp { get; set; } = DateTime.Now;

        public string? Collisions { get; set; }

        public decimal Result { get; set; } 
    }
}
