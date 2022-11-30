using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCarRentalSystem.Interfaces;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.Services;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Passport = user.Passport,
                    DYears = user.DYears,
                    Rating = user.Rating,
                    HomeAddress = user.HomeAddress,
                    Telephone = user.Telephone
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return RedirectToAction("Index", "Users");
            }

            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Passport = user.Passport,
                DYears = user.DYears,
                Rating = user.Rating,
                HomeAddress = user.HomeAddress,
                Telephone = user.Telephone
            };
            return View(userDetailViewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            var editMV = new EditProfileViewModel()
            {
                Passport = user.Passport,
                DYears = user.DYears,
                Rating = user.Rating,
                HomeAddress = user.HomeAddress,
                Telephone = user.Telephone
            };
            return View(editMV);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(EditProfileViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditProfile", editVM);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return View("Error");
            }

            //if (editVM.Image != null) // only update profile image
            //{
            //    var photoResult = await _photoService.AddPhotoAsync(editVM.Image);

            //    if (photoResult.Error != null)
            //    {
            //        ModelState.AddModelError("Image", "Failed to upload image");
            //        return View("EditProfile", editVM);
            //    }

            //    if (!string.IsNullOrEmpty(user.ProfileImageUrl))
            //    {
            //        _ = _photoService.DeletePhotoAsync(user.ProfileImageUrl);
            //    }

            //    user.ProfileImageUrl = photoResult.Url.ToString();
            //    editVM.ProfileImageUrl = user.ProfileImageUrl;

            //    await _userManager.UpdateAsync(user);

            //    return View(editVM);
            //}

            user.Passport = editVM.Passport;
            user.DYears = editVM.DYears;
            user.Rating = editVM.Rating;
            user.HomeAddress = editVM.HomeAddress;
            user.Telephone = editVM.Telephone;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Detail", "User", new { user.Id });
        }
    }
}
