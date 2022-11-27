using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels.Contract;

namespace WebCarRentalSystem.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractRepository _contractRepository;
        public ContractController(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Contract> contracts = await _contractRepository.GetAll();
            return View(contracts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateContractViewModel contractVM)
        {
            if (ModelState.IsValid)
            {
                var contract = new Contract
                {
                    DateContract = contractVM.DateContract,
                    DateEnd = contractVM.DateEnd,
                    ClientID = contractVM.ClientID,
                    CarId = contractVM.CarId,
                    ContractDays = contractVM.ContractDays,
                    Price = contractVM.Price
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
                ClientID = contract.ClientID,
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
                    ClientID = contractVM.ClientID,
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
