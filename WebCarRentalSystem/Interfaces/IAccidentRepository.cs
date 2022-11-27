using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Interfaces
{
    public interface IAccidentRepository
    {
        Task<IEnumerable<Accident>> GetAll();
        Task<Accident> GetByIdAsync(int id);
        Task<Accident> GetByIdAsyncNoTracking(int id);
        bool Add(Accident accident);
        bool Edit(Accident accident);
        bool Delete(Accident accident);
        bool Save();
    }
}
