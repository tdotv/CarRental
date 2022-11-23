using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Car> cars = await _carRepository.GetAll();
            return View(cars);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            _carRepository.Add(car);
            TempData["success"] = "Car created successfully";
            return RedirectToAction("Index");
        }

        //// GET
        //public IActionResult Edit(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    var carFromDb = _context.Car.Find(id);
        //    //var carFromDbFirst=_context.Car.FirstOrDefault(x => x.Id==id);
        //    //var carFromDbSingle=_context.Car.SingleOrDefault(x=>x.Id==id);

        //    if (carFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View();
        //}

        //// POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Car obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Car.Update(obj);
        //        _context.SaveChanges();
        //        TempData["success"] = "Car updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}

        //// GET
        //public IActionResult Delete(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    var carFromDb = _context.Car.Find(id);
        //    //var carFromDbFirst=_context.Car.FirstOrDefault(x => x.Id==id);
        //    //var carFromDbSingle=_context.Car.SingleOrDefault(x=>x.Id==id);

        //    if (carFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View();
        //}

        //// POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePOST(int? id)
        //{
        //    var obj = _context.Car.Find(id);
        //    if (obj == null) { return NotFound(); }

        //    _context.Car.Remove(obj);
        //    _context.SaveChanges();
        //    TempData["success"] = "Car deleted successfully";
        //    return RedirectToAction("Index");
        //}
    }
}
