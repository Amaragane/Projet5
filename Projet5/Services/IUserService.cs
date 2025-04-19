using Microsoft.AspNetCore.Identity;
using Projet5.Models;
using Projet5.ViewModels;
using System.Threading.Tasks;

namespace Projet5.Services
{
    public interface IUserService
    {

        Task<bool> IsCurrentUserAdminAsync();
        Task<UserModel> GetCurrentUserAsync();
        Task<UserModel> GetUserByIdentifiantAsync(string identifiant);
        Task CreateUserAsync(UserModel user);
    }
}
