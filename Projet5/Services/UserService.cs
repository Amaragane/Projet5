using Microsoft.EntityFrameworkCore;
using Projet5.Data;
using Projet5.Models;
using System.Security.Claims;

namespace Projet5.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
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

            // Rechercher l'utilisateur dans notre table personnalisée
            var customUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Identifiant == userEmail);

            // Vérifier si l'utilisateur existe et est administrateur
            return customUser != null && customUser.EstAdministateur;
        }
    }
}
