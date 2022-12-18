using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ApplicationUser user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(ApplicationUser user)
        {
            _context.Remove(user);
            return Save();
        }

        public bool Edit(ApplicationUser user)
        {
            _context.Update(user);
            return Save();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers() => await _context.Users.ToListAsync();

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersNoTracking() =>  await _context.Users.AsNoTracking().ToListAsync();

        public async Task<ApplicationUser> GetUserById(string id) => await _context.Users.FindAsync(id);

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
