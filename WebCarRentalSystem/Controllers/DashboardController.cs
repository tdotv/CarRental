using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userContracts = await _dashboardRepository.GetAllUserContracts();
            var dashboardViewModel = new DashboardViewModel()
            {
                Contracts = userContracts,
            };
            
            return View(dashboardViewModel);
        }

    }
}
