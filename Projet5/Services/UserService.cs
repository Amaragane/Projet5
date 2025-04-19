using Microsoft.EntityFrameworkCore;
using Projet5.Models;
using Projet5.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projet5.Services
{


    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsCurrentUserAdminAsync()
        {
            // Vérifier si l'utilisateur est connecté
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return false;

            // Récupérer l'email de l'utilisateur connecté
            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(userEmail))
                return false;

            // Vérifier si l'utilisateur est administrateur
            return await _userRepository.IsUserAdminAsync(userEmail);
        }

        public async Task<UserModel> GetCurrentUserAsync()
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                return null;

            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            if (string.IsNullOrEmpty(userEmail))
                return null;

            return await _userRepository.GetUserByIdentifiantAsync(userEmail);
        }

        public async Task<UserModel> GetUserByIdentifiantAsync(string identifiant)
        {
            return await _userRepository.GetUserByIdentifiantAsync(identifiant);
        }

        public async Task CreateUserAsync(UserModel user)
        {
            await _userRepository.AddUserAsync(user);
        }
    }
}
