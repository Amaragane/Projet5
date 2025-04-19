using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projet5.Models;
using Projet5.Services;
using Projet5.ViewModels;
using System.Threading.Tasks;

namespace Projet5.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AccountController(
            IAuthService authService,
            IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (result, user) = await _authService.RegisterUserAsync(model);

                if (result.Succeeded)
                {
                    // Créer un UserMode correspondant
                    bool customUserCreated = await _authService.CreateCustomUserAsync(model.Email);

                    if (!customUserCreated)
                    {
                        ModelState.AddModelError(string.Empty, "Erreur lors de la création du profil utilisateur.");
                        return View(model);
                    }

                    // Connexion automatique après inscription
                    var signInResult = await _authService.LoginUserAsync(new LoginViewModel 
                    { 
                        Email = model.Email, 
                        Password = model.Password 
                    });
                    
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUserAsync(model);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Tentative de connexion invalide.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutUserAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            return View(currentUser);
        }
    }
}
