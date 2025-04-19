using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Projet5.Services;

namespace Projet5.Filters
{
    public class AdminAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IUserService _userService;

        public AdminAuthorizationFilter(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // Vérifier si l'utilisateur est administrateur
            var isAdmin = await _userService.IsCurrentUserAdminAsync();

            if (!isAdmin)
            {
                // Rediriger vers la page d'accueil si l'utilisateur n'est pas administrateur
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }

    public class AdminOnlyAttribute : TypeFilterAttribute
    {
        public AdminOnlyAttribute() : base(typeof(AdminAuthorizationFilter))
        {
        }
    }
}
