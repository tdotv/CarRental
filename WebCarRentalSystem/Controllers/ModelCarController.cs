using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Controllers
{
    public class ModelCarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ModelCarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ModelCar> objCategoryList = _context.ModelCar;
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ModelCar obj)
        {
            if (ModelState.IsValid)
            {
                _context.ModelCar.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Model created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var carFromDb = _context.ModelCar.Find(id);

            if (carFromDb == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ModelCar obj)
        {
            if (ModelState.IsValid)
            {
                _context.ModelCar.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Model updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var carFromDb = _context.ModelCar.Find(id);

            if (carFromDb == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.ModelCar.Find(id);
            if (obj == null) { return NotFound(); }

            _context.ModelCar.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Model deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
