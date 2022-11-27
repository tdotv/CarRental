using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Client client)
        {
            _context.Add(client);
            return Save();
        }

        public bool Delete(Client client)
        {
            _context.Remove(client);
            return Save();
        }

        public bool Edit(Client client)
        {
            _context.Update(client);
            return Save();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Client.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Client> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Client.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
