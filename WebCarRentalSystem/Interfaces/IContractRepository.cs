using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Interfaces
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> GetAll();
        Task<IEnumerable<Contract>> GetAllNoTracking();
        Task<Contract> GetByIdAsync(int id);
        Task<Contract> GetByIdAsyncNoTracking(int id);
        bool Add(Contract contract);
        bool Edit(Contract contract);
        bool Delete(Contract contract);
        bool Save();
    }
}
