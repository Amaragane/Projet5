using Microsoft.AspNetCore.Mvc;
using Projet5.Services;
using System.Threading.Tasks;

namespace Projet5.ViewComponents
{
    public class AdminMenuViewComponent : ViewComponent
    {
        private readonly UserService _userService;

        public AdminMenuViewComponent(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            bool isAdmin = await _userService.IsCurrentUserAdminAsync();
            return View(isAdmin);
        }
    }
}
