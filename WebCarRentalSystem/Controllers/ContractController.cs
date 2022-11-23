using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Controllers
{
    public class ContractController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContractController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Contract> contracts = _context.Contract.ToList();
            return View(contracts);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contract obj)
        {
            if (ModelState.IsValid)
            {
                _context.Contract.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Contract created successfully";
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
            var carFromDb = _context.Contract.Find(id);

            if (carFromDb == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contract obj)
        {
            if (ModelState.IsValid)
            {
                _context.Contract.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Contract updated successfully";
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
            var carFromDb = _context.Contract.Find(id);

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
            var obj = _context.Contract.Find(id);
            if (obj == null) { return NotFound(); }

            _context.Contract.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Contract deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
