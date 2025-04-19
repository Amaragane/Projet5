using Microsoft.AspNetCore.Identity;
using Projet5.Models;
using Projet5.ViewModels;
using System.Threading.Tasks;

namespace Projet5.Services
{
    public interface IAuthService
    {
        Task<(IdentityResult Result, IdentityUser User)> RegisterUserAsync(RegisterViewModel model);
        Task<Microsoft.AspNetCore.Identity.SignInResult> LoginUserAsync(LoginViewModel model);
        Task LogoutUserAsync();
        Task<bool> CreateCustomUserAsync(string email);
    }
}
