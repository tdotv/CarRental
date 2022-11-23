using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Models;

namespace WebCarRentalSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Client> clients = _context.Client.ToList();
            return View(clients);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client obj)
        {
            if (ModelState.IsValid)
            {
                _context.Client.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Client created successfully";
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
            var carFromDb = _context.Client.Find(id);

            if (carFromDb == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                _context.Client.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Client updated successfully";
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
            var carFromDb = _context.Client.Find(id);

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
            var obj = _context.Client.Find(id);
            if (obj == null) { return NotFound(); }

            _context.Client.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Client deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
