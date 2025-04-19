using Projet5.Models;
using System.Threading.Tasks;

namespace Projet5.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByIdentifiantAsync(string identifiant);
        Task<bool> IsUserAdminAsync(string identifiant);
        Task AddUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task<bool> UserExistsAsync(string identifiant);
    }
}
