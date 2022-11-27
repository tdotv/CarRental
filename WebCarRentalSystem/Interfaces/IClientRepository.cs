using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetByIdAsync(int id);
        Task<Client> GetByIdAsyncNoTracking(int id);
        bool Add(Client client);
        bool Edit(Client client);
        bool Delete(Client client);
        bool Save();
    }
}
