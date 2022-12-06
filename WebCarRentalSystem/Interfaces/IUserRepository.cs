using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<IEnumerable<ApplicationUser>> GetAllUsersNoTracking();
        Task<ApplicationUser> GetUserById(string id);
        bool Add(ApplicationUser user);
        bool Edit(ApplicationUser user);
        bool Delete(ApplicationUser user);
        bool Save();
    }
}
