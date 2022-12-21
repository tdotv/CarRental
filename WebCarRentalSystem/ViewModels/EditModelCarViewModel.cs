namespace WebCarRentalSystem.ViewModels
{
    public class EditModelCarViewModel
    {
        public string Class { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }
        public IFormFile? Image { get; set; }
        public string? URL { get; set; }
        public string Description { get; set; }
        public decimal FuelConsumption { get; set; }
        public string Transmission { get; set; }
        public decimal EngineValue { get; set; }
        public string ManufactureYear { get; set; }
    }
}
