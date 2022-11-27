using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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

        public Task<IEnumerable<Contract>> GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Contract>> GetAll()
        //{
        //    var curUser = _httpContextAccessor.HttpContext?.User;
        //    var userContracts = _context.Contract.Where(r => r.ApplicationUser.Id == curUser.ToString());
        //    return userContracts.ToList();
        //}

        public async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contract.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
