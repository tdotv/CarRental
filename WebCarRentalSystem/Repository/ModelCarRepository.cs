using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Repository
{
    public class ModelCarRepository : IModelCarRepository
    {
        private readonly ApplicationDbContext _context;
        public ModelCarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ModelCar model)
        {
            _context.Add(model);
            return Save();
        }

        public bool Delete(ModelCar model)
        {
            _context.Remove(model);
            return Save();
        }

        public bool Edit(ModelCar model)
        {
            _context.Update(model);
            return Save();
        }

        public async Task<IEnumerable<ModelCar>> GetAll()
        {
            return await _context.ModelCar.ToListAsync();
        }

        public async Task<ModelCar> GetByIdAsync(int id) => await _context.ModelCar?.FirstOrDefaultAsync(i => i.Id == id);

        public async Task<ModelCar> GetByIdAsyncNoTracking(int id) => await _context.ModelCar?.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

        public async Task<IEnumerable<ModelCar>> GetModelByClass(string Class)
        {
            return await _context.ModelCar.Where(c => c.Equals(Class)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
