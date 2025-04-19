using Microsoft.AspNetCore.Identity;
using Projet5.Models;
using Projet5.Repositories;
using Projet5.ViewModels;
using System.Threading.Tasks;

namespace Projet5.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public AuthService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<(IdentityResult Result, IdentityUser User)> RegisterUserAsync(RegisterViewModel model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            return (result, user);
        }

        public async Task<bool> CreateCustomUserAsync(string email)
        {
            try
            {
                // Créer un UserModel correspondant
                var customUser = new UserModel
                {
                    Identifiant = email,
                    MotDePasse = "HashedByIdentity", // Note: le mot de passe est géré par Identity
                    EstAdministrateur = false // Par défaut, les nouveaux utilisateurs ne sont pas admin
                };

                await _userRepository.AddUserAsync(customUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<SignInResult> LoginUserAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false);
        }

        public async Task LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
