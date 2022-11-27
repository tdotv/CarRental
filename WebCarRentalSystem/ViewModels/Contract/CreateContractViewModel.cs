using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using WebCarRentalSystem.Models;
using Microsoft.Build.Framework;

namespace WebCarRentalSystem.ViewModels.Contract
{
    public class CreateContractViewModel
    {
        public DateTime? DateContract { get; set; }
        public DateTime? DateEnd { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public int CarId { get; set; }
        public decimal? ContractDays { get; set; }
        public decimal? Price { get; set; }
    }
}
