using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractRepository _contractRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public ContractController(IContractRepository contractRepository, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _contractRepository = contractRepository;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index(int page = 0)
        {
            const int PageSize = 5;

            IEnumerable<Contract> contracts = await _contractRepository.GetAll();

            var count = contracts.Count();
            var data = contracts.Skip(page * PageSize).Take(PageSize).ToList();

            //  Pagination
            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            ViewBag.Page = page;

            return View(data);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor?.HttpContext?.User.GetUserId();
            return View("Create", ViewModelFactory.CreateContract(curUserId, new Contract(), _context.ModelCar));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateContractViewModel contractVM)
        {
            if (ModelState.IsValid)
            {
                var contractDays = contractVM.DateEnd.Subtract(contractVM.DateContract);
                var contract = new Contract
                {
                    DateContract = contractVM.DateContract,
                    DateEnd = contractVM.DateEnd,
                    CarId = contractVM.CarId,
                    ContractDays = contractDays.Days,
                    Price = contractDays.Days * 80,
                    ApplicationUserId = contractVM.ApplicationUserId
                };

                _contractRepository.Add(contract);
                TempData["success"] = "Contract created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Can't create new contract");
            }
            return View(contractVM);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null) { return View("Error"); }
            var contractVM = new EditContractViewModel
            {
                DateContract = contract.DateContract,
                DateEnd = contract.DateEnd,
                CarId = contract.CarId,
                ContractDays = contract.ContractDays,
                Price = contract.Price
            };
            return View(contractVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditContractViewModel contractVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit contract");
                return View("Edit", contractVM);
            }
            var contractModel = await _contractRepository.GetByIdAsyncNoTracking(id);
            if (contractModel != null)
            {
                var contract = new Contract
                {
                    Id = id,
                    DateContract = contractVM.DateContract,
                    DateEnd = contractVM.DateEnd,
                    CarId = contractVM.CarId,
                    ContractDays = contractVM.DateEnd.Day - contractVM.DateContract.Day,
                    Price = (contractVM.DateEnd.Day - contractVM.DateContract.Day) * 80,
                };
                _contractRepository.Edit(contract);
                TempData["success"] = "Contract updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(contractVM);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var contractDetails = await _contractRepository.GetByIdAsync(id);
            if (contractDetails == null) return View("Error");
            return View(contractDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            var contractDetails = await _contractRepository.GetByIdAsync(id);

            if (contractDetails == null)
            {
                return View("Error");
            }

            _contractRepository.Delete(contractDetails);
            TempData["success"] = "Contract deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
