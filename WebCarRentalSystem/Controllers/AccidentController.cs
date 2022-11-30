using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class AccidentController : Controller
    {
        private readonly IAccidentRepository _accidentRepository;
        public AccidentController(IAccidentRepository accidentRepository)
        {
            _accidentRepository = accidentRepository;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, int page = 1)
        {
            ViewBag.DateDtpSortParm = sortOrder == "DateDtp" ? "dateDtp_desc" : "DateDtp";
            ViewBag.CollisionsSortParm = sortOrder == "Collisions" ? "collisions_desc" : "Collisions";
            ViewBag.ResultSortParm = sortOrder == "Result" ? "result_desc" : "Result";
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Accident> accidents = await _accidentRepository.GetAllNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                accidents = accidents.Where(s => s.Collisions.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "DateDtp":
                    accidents = accidents.OrderBy(s => s.DateDtp);
                    break;
                case "dateDtp_desc":
                    accidents = accidents.OrderByDescending(s => s.DateDtp);
                    break;
                case "Collisions":
                    accidents = accidents.OrderBy(s => s.Collisions);
                    break;
                case "collisions_desc":
                    accidents = accidents.OrderByDescending(s => s.Collisions);
                    break;
                case "Result":
                    accidents = accidents.OrderBy(s => s.Result);
                    break;
                case "result_desc":
                    accidents = accidents.OrderByDescending(s => s.Result);
                    break;
            }
            return View(accidents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAccidentViewModel accidentVM)
        {
            if (ModelState.IsValid)
            {
                var accident = new Accident
                {
                    ContractId = accidentVM.ContractId,
                    DateDtp = accidentVM.DateDtp,
                    Collisions = accidentVM.Collisions,
                    Result = accidentVM.Result
                };
                _accidentRepository.Add(accident);
                TempData["success"] = "Accident created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Can't create new accident");
            }
            return View(accidentVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var accident = await _accidentRepository.GetByIdAsync(id);
            if (accident == null) { return View("Error"); }
            var accidentVM = new EditAccidentViewModel
            {
                ContractId = accident.ContractId,
                DateDtp = accident.DateDtp,
                Collisions = accident.Collisions,
                Result = accident.Result
            };
            return View(accidentVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditAccidentViewModel accidentVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit accident");
                return View("Edit", accidentVM);
            }
            var accidentModel = await _accidentRepository.GetByIdAsyncNoTracking(id);
            if (accidentModel != null)
            {
                var accident = new Accident
                {
                    Id = id,
                    ContractId = accidentVM.ContractId,
                    DateDtp = accidentVM.DateDtp,
                    Collisions = accidentVM.Collisions,
                    Result = accidentVM.Result
                };
                _accidentRepository.Edit(accident);
                TempData["success"] = "Accident updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(accidentVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var accidentDetails = await _accidentRepository.GetByIdAsync(id);
            if (accidentDetails == null) return View("Error");
            return View(accidentDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAccident(int id)
        {
            var accidentDetails = await _accidentRepository.GetByIdAsync(id);

            if (accidentDetails == null)
            {
                return View("Error");
            }

            _accidentRepository.Delete(accidentDetails);
            TempData["success"] = "Accident deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
