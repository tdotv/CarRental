using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Repository
{
    public class CarRepository : ICarRepository
    {

        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context= context;
        }

        public bool Add(Car car)
        {
            _context.Add(car);
            return Save();
        }

        public bool Delete(Car car)
        {
            _context.Remove(car);
            return Save();
        }

        public bool Edit(Car car)
        {
            _context.Update(car);
            return Save();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Car.Include(i => i.Model).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAllNoTracking()
        {
            return await _context.Car.AsNoTracking().ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Car?.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Car> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Car?.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Car>> GetCarByCity(string city)
        {
            return await _context.Car.Include(i => i.Model).Where(i => i.City.Equals(city)).Distinct().ToListAsync();
        }

        //public async Task<IEnumerable<Car>> GetSliceAsync(int offset, int size)
        //{
        //    return await _context.Car.Include(i => i.Model).Skip(offset).Take(size).ToListAsync();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
