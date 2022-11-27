using WebCarRentalSystem.Models;


namespace WebCarRentalSystem.Interfaces
{
    public interface IDashboardRepository
    {
        Task<IEnumerable<Contract>> GetAll();
        Task<Contract> GetByIdAsync(int id);
        bool Add(Contract contract);
        bool Edit(Contract contract);
        bool Delete(Contract contract);
        bool Save();
    }
}
