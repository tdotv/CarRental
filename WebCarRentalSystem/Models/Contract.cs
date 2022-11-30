using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCarRentalSystem.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Date Contract")]
        public DateTime? DateContract { get; set; }

        [DisplayName("Date End")]
        public DateTime? DateEnd { get; set; }

        [ForeignKey("Car")]
        public int? CarId { get; set; }
        public Car? Car { get; set; }

        [DisplayName("Contract Days")]
        public decimal? ContractDays { get; set; }

        public decimal? Price { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
