using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using WebCarRentalSystem.Helpers;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;

        public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var homeViewModel = new HomeViewModel();
            try
            {
                string url = "https://ipinfo.io?token=9c106f21cf32e4";
                string info = await new HttpClient().GetStringAsync(url);
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRegionInfo = new(ipInfo.Country);
                ipInfo.Country = myRegionInfo.EnglishName;
                homeViewModel.City = ipInfo.City;
                homeViewModel.Region = ipInfo.Region;
                if (homeViewModel.City != null)
                {
                    homeViewModel.Cars = await _carRepository.GetCarByCity(homeViewModel.City);
                }
                else
                {
                    homeViewModel.Cars = null;
                }
                return View(homeViewModel);
            }
            catch (Exception)
            {
                homeViewModel.Cars = null;
            }
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}