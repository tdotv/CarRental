using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Repository
{
    public class AccidentRepository : IAccidentRepository
    {
        private readonly ApplicationDbContext _context;
        public AccidentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Accident accident)
        {
            _context.Add(accident);
            return Save();
        }

        public bool Delete(Accident accident)
        {
            _context.Remove(accident);
            return Save();
        }

        public bool Edit(Accident accident)
        {
            _context.Update(accident);
            return Save();
        }

        public async Task<IEnumerable<Accident>> GetAll()
        {
            return await _context.Accident.Include(p => p.Contract).ToListAsync();
        }

        public async Task<IEnumerable<Accident>> GetAllNoTracking()
        {
            return await _context.Accident.AsNoTracking().ToListAsync();
        }

        public async Task<Accident> GetByIdAsync(int id)
        {
            return await _context.Accident.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Accident> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Accident.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
