using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.ViewModels.Dashboard;

namespace WebCarRentalSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userContracts = await _dashboardRepository.GetAll();
            var dashboardViewModel = new DashboardViewModel()
            {
                DateContract = DateTime.Now,
                //DateEnd = dashboardViewModel.DateEnd,

            };
            return View(dashboardViewModel);
        }
    }
}
