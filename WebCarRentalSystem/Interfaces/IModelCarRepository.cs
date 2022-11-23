using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Interfaces
{
    public interface IModelCarRepository
    {
        Task<IEnumerable<ModelCar>> GetAll();
        Task<ModelCar> GetByIdAsync(int id);
        Task<ModelCar> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<ModelCar>> GetModelByClass(string Class);
        bool Add(ModelCar model);
        bool Edit(ModelCar model);
        bool Delete(ModelCar model);
        bool Save();
    }
}
