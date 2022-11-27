using Microsoft.Build.Framework;

namespace WebCarRentalSystem.ViewModels.Client
{
    public class CreateClientViewModel
    {
        public string? Passport { get; set; }
        public string? DYears { get; set; }
        public decimal? Rating { get; set; }
        public string? HomeAddress { get; set; }
        [Required]
        public decimal Telephone { get; set; }
    }
}
