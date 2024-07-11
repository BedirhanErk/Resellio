using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resellio.Web.Models;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var userInfo = await _userService.GetUser();

            return View(userInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserUpdateInput userUpdateInput)
        {
            var userInfo = await _userService.GetUser();

            if (!ModelState.IsValid)
                return View(userInfo);

            await _userService.UpdateUser(userUpdateInput);

            return RedirectToAction(nameof(Index));
        }
    }
}
