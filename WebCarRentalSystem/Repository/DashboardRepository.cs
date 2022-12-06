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

        public Task<List<Accident>> GetAllUserAccidents()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userAccidents = _context.Accident.Where(r => r.ApplicationUser.Id == curUser);
            return Task.FromResult(userAccidents.ToList());
        }

        public Task<List<Contract>> GetAllUserContracts()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userContracts = _context.Contract.Where(r => r.ApplicationUser.Id == curUser);
            return Task.FromResult(userContracts.ToList());
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<ApplicationUser> GetUserByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Edit(ApplicationUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save ()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
