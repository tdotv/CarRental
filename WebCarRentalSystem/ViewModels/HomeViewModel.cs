using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
