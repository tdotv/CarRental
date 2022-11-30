using Microsoft.AspNetCore.Mvc;
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
            return await _context.Car.ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetAllNoTracking()
        {
            return await _context.Car.AsNoTracking().ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Car.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Car> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Car.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        //?????????
        public async Task<IEnumerable<Car>> GetCarByRegNum(string CarRegNumber)
        {
            return await _context.Car.Where(c => c.Equals(CarRegNumber)).ToListAsync(); 
        }
        //-------------------------------------------------------------------------------------

        public async Task<IEnumerable<Car>> GetModel(string model)
        {
            return await _context.Car.Where(c => c.Model.Model.Contains(model)).ToListAsync();
        }
        public async Task<IEnumerable<Car>> GetMarka(string model)
        {
            return await _context.Car.Where(c => c.Model.Marka.Contains(model)).ToListAsync();
        }
        //-------------------------------------------------------------------------------------

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
