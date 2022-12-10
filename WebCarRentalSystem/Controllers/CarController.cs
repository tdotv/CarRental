using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.RentedSortParm = sortOrder == "Rented" ? "rented_desc" : "Rented";
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Car> cars = await _carRepository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Model.Marka.Contains(searchString)
                                       || s.Model.Model.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Rented":
                    cars = cars.OrderBy(s => s.Rented);
                    break;
                case "rented_desc":
                    cars = cars.OrderByDescending(s => s.Rented);
                    break;
            }
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    ModelCarId = carVM.ModelCarId,
                    Color = carVM.Color,
                    Rented = carVM.Rented,
                    CarRegNumber = carVM.CarRegNumber,
                    City = carVM.City,
                };
                _carRepository.Add(car);
                TempData["success"] = "Car created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Can't create new car");
            }
            return View(carVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null) { return View("Error"); }
            var carVM = new EditCarViewModel
            {
                ModelCarId = car.ModelCarId,
                Color = car.Color,
                Rented = car.Rented,
                CarRegNumber = car.CarRegNumber,
                City = car.City,
            };
            return View(carVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit car");
                return View("Edit", carVM);
            }
            var carModel = await _carRepository.GetByIdAsyncNoTracking(id);
            if (carModel != null)
            {
                var car = new Car
                {
                    Id = id,
                    ModelCarId = carVM.ModelCarId,
                    Color = carVM.Color,
                    Rented = carVM.Rented,
                    CarRegNumber = carVM.CarRegNumber,
                    City = carVM.City,
                };
                _carRepository.Edit(car);
                TempData["success"] = "Car updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(carVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View("Error");
            return View(carDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);

            if (carDetails == null)
            {
                return View("Error");
            }

            _carRepository.Delete(carDetails);
            TempData["success"] = "Car deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
