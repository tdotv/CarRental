using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDbContext _context;
        public ContractRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Contract contract)
        {
            _context.Add(contract);
            return Save();
        }

        public bool Delete(Contract contract)
        {
            _context.Remove(contract);
            return Save();
        }

        public bool Edit(Contract contract)
        {
            _context.Update(contract);
            return Save();
        }

        public async Task<IEnumerable<Contract>> GetAll()
        {
            return await _context.Contract.Include(i => i.Car).ToListAsync();
        }

        public async Task<IEnumerable<Contract>> GetAllNoTracking()
        {
            return await _context.Contract.AsNoTracking().ToListAsync();
        }

        public async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contract?.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Contract> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Contract?.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
