using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public DateTime DateContract { get; set; }
        public DateTime DateEnd { get; set; }
        public int ClientID { get; set; }
        public int CarId { get; set; }
        public decimal ContractDays { get; set; }
        public decimal Price { get; set; }
    }
}
