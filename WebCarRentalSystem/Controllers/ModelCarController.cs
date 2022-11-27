using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels.ModelCar;

namespace WebCarRentalSystem.Controllers
{
    public class ModelCarController : Controller
    {
        private readonly IModelCarRepository _modelRepository;
        private readonly IPhotoService _photoService;
        public ModelCarController(IModelCarRepository modelRepository, IPhotoService photoService)
        {
            _modelRepository = modelRepository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ModelCar> models = await _modelRepository.GetAll();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModelCarViewModel modelVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(modelVM.Image);

                var model = new ModelCar
                {
                    Class = modelVM.Class,
                    Model = modelVM.Model,
                    Marka = modelVM.Marka,
                    Description = modelVM.Description,
                    FuelConsumption = modelVM.FuelConsumption,
                    Transmission = modelVM.Transmission,
                    EngineValue = modelVM.EngineValue,
                    ManufactureYear = modelVM.ManufactureYear,
                    Image = result.Url.ToString()
                };
                _modelRepository.Add(model);
                TempData["success"] = "Model created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(modelVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _modelRepository.GetByIdAsync(id);
            if (model == null) { return View("Error"); }
            var modelVM = new EditModelCarViewModel
            {
                Class = model.Class,
                Model = model.Model,
                Marka = model.Marka,
                Description = model.Description,
                FuelConsumption = model.FuelConsumption,
                Transmission = model.Transmission,
                EngineValue = model.EngineValue,
                ManufactureYear = model.ManufactureYear,
                URL = model.Image
            };
            return View(modelVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditModelCarViewModel modelVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit model");
                return View("Edit", modelVM);
            }
            var userModel = await _modelRepository.GetByIdAsyncNoTracking(id);
            if (userModel != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userModel.Image);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(modelVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(modelVM.Image);

                var model = new ModelCar
                {
                    Id = id,
                    Class = modelVM.Class,
                    Model = modelVM.Model,
                    Marka = modelVM.Marka,
                    Description = modelVM.Description,
                    FuelConsumption = modelVM.FuelConsumption,
                    Transmission = modelVM.Transmission,
                    EngineValue = modelVM.EngineValue,
                    ManufactureYear = modelVM.ManufactureYear,
                    Image = photoResult.Url.ToString()
                };
                _modelRepository.Edit(model);
                TempData["success"] = "Model updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(modelVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var modelDetails = await _modelRepository.GetByIdAsync(id);
            if (modelDetails == null) return View("Error");
            return View(modelDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var modelDetails = await _modelRepository.GetByIdAsync(id);

            if (modelDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(modelDetails.Image))
            {
                _ = _photoService.DeletePhotoAsync(modelDetails.Image);
            }

            _modelRepository.Delete(modelDetails);
            TempData["success"] = "Model deleted successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            ModelCar model = await _modelRepository.GetByIdAsync(id);
            return View(model);
        }
    }
}
