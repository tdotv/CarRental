using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractRepository _contractRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ContractController(IContractRepository contractRepository, IHttpContextAccessor httpContextAccessor)
        {
            _contractRepository = contractRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.DateContractSortParm = sortOrder == "DateContract" ? "dateContract_desc" : "DateContract";
            ViewBag.DateEndSortParm = sortOrder == "DateEnd" ? "dateEnd_desc" : "DateEnd";
            ViewBag.ContractDaysSortParm = sortOrder == "ContractDays" ? "contractDays_desc" : "ContractDays";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            IEnumerable<Contract> contracts = await _contractRepository.GetAll();

            switch (sortOrder)
            {
                case "DateContract":
                    contracts = contracts.OrderBy(s => s.DateContract);
                    break;
                case "dateContract_desc":
                    contracts = contracts.OrderByDescending(s => s.DateContract);
                    break;
                case "DateEnd":
                    contracts = contracts.OrderBy(s => s.DateEnd);
                    break;
                case "dateEnd_desc":
                    contracts = contracts.OrderByDescending(s => s.DateEnd);
                    break;
                case "ContractDays":
                    contracts = contracts.OrderByDescending(s => s.ContractDays);
                    break;
                case "contractDays_desc":
                    contracts = contracts.OrderByDescending(s => s.ContractDays);
                    break;
                case "Price":
                    contracts = contracts.OrderByDescending(s => s.Price);
                    break;
                case "price_desc":
                    contracts = contracts.OrderByDescending(s => s.Price);
                    break;
            }
            return View(contracts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createContractViewModel = new CreateContractViewModel
            {
                ApplicationUserId = curUserId
            };
            return View(createContractViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateContractViewModel contractVM)
        {
            if (ModelState.IsValid)
            {
                var contract = new Contract
                {
                    DateContract = contractVM.DateContract,
                    DateEnd = contractVM.DateEnd,
                    CarId = contractVM.CarId,
                    ContractDays = contractVM.DateEnd.Day - contractVM.DateContract.Day,
                    Price = (contractVM.DateEnd.Day - contractVM.DateContract.Day) * 80,
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
                    ContractDays = contractVM.ContractDays,
                    Price = contractVM.Price
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
