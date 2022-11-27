using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels.Client;

namespace WebCarRentalSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Client> clients = await _clientRepository.GetAll();
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateClientViewModel clientVM)
        {
            if (ModelState.IsValid)
            {
                var client = new Client
                {
                    Passport = clientVM.Passport,
                    DYears = clientVM.DYears,
                    Rating = clientVM.Rating,
                    HomeAddress = clientVM.HomeAddress,
                    Telephone = clientVM.Telephone
                };
                _clientRepository.Add(client);
                TempData["success"] = "Client created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Can't create new client");
            }
            return View(clientVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client == null) { return View("Error"); }
            var clientVM = new EditClientViewModel
            {
                Passport = client.Passport,
                DYears = client.DYears,
                Rating = client.Rating,
                HomeAddress = client.HomeAddress,
                Telephone = client.Telephone
            };
            return View(clientVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClientViewModel clientVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit client");
                return View("Edit", clientVM);
            }
            var clientModel = await _clientRepository.GetByIdAsyncNoTracking(id);
            if (clientModel != null)
            {
                var client = new Client
                {
                    Id = id,
                    Passport = clientVM.Passport,
                    DYears = clientVM.DYears,
                    Rating = clientVM.Rating,
                    HomeAddress = clientVM.HomeAddress,
                    Telephone = clientVM.Telephone
                };
                _clientRepository.Edit(client);
                TempData["success"] = "Client updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(clientVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var clientDetails = await _clientRepository.GetByIdAsync(id);
            if (clientDetails == null) return View("Error");
            return View(clientDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var clientDetails = await _clientRepository.GetByIdAsync(id);

            if (clientDetails == null)
            {
                return View("Error");
            }

            _clientRepository.Delete(clientDetails);
            TempData["success"] = "Client deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
