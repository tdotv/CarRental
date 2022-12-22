using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCarRentalSystem.Areas.Identity.Data.DataAnnotations;

namespace WebCarRentalSystem.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateContract { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        public decimal ContractDays { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
