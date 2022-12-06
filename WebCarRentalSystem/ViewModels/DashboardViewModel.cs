using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.ViewModels
{
    public class DashboardViewModel
    {
        public List<Accident> Accidents { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
