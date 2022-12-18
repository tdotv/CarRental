using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebCarRentalSystem.Areas.Identity.Data;
using WebCarRentalSystem.Models;
using WebCarRentalSystem.ViewModels;

namespace WebCarRentalSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel response)
        {
            if (!ModelState.IsValid)
            {
                return View(response);
            }
            var user = await _userManager.FindByEmailAsync(response.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, response.Password);
                if (passwordCheck)
                {
                    //  Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, response.Password, false, false);
                    if (result.Succeeded)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, response.Email)
                        };
                        var identity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var props = new AuthenticationProperties();
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                        return RedirectToAction("Index", "Home");
                    }
                }
                //  Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(response);
            }
            //  User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(response);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Wrong credentials");
                return View(registerViewModel);
            }

            var user = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already used";
                return View(registerViewModel);

            }

            var newUser = new ApplicationUser()
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            foreach (var error in newUserResponse.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
