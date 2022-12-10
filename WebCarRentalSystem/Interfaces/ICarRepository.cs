using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();
        Task<IEnumerable<Car>> GetAllNoTracking();
        Task<Car> GetByIdAsync(int id);
        Task<Car> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Car>> GetCarByCity(string city);
        bool Add(Car car);
        bool Edit(Car car);
        bool Delete(Car car);
        bool Save();
    }
}
