using WebCarRentalSystem.Models;


namespace WebCarRentalSystem.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Contract>> GetAllUserContracts();
        Task<ApplicationUser> GetUserById(string id);
        Task<ApplicationUser> GetUserByIdNoTracking(string id);
        bool Edit(ApplicationUser user);
        bool Save();
    }
}
