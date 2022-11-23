using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetCarByRegNum(string CarRegNumber);
        bool Add(Car car);
        bool Edit(Car car);
        bool Delete(Car car);
        bool Save();
    }
}
