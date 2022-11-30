using WebCarRentalSystem.Models;


namespace WebCarRentalSystem.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Contract>> GetAllUserContracts();
        Task<List<Accident>> GetAllUserAccidents();
    }
}
