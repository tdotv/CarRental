using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Controllers
{
    public class AccidentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccidentController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Accident> accidents = _context.Accident.ToList();
            return View(accidents);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Accident obj)
        {
            if (ModelState.IsValid)
            {
                _context.Accident.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Accident created successfully";
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
            var carFromDb = _context.Accident.Find(id);

            if (carFromDb == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Accident obj)
        {
            if (ModelState.IsValid)
            {
                _context.Accident.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Accident updated successfully";
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
            var carFromDb = _context.Accident.Find(id);

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
            var obj = _context.Accident.Find(id);
            if (obj == null) { return NotFound(); }

            _context.Accident.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Accident deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
