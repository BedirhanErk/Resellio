using Resellio.Web.Models;
using Resellio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Resellio.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;

        public AuthController(IIdentityService identityService, IUserService userService)
        {
            _identityService = identityService;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInput loginInput)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _identityService.Login(loginInput);

            if (!response.IsSuccessful)
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError(String.Empty, error);
                }

                return View();
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            await _identityService.RevokeRefreshToken();

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupInput signupInput)
        {
            if (!ModelState.IsValid)
                return View();

            var response = await _userService.Signup(signupInput);

            if (response != true)
                return View();

            return RedirectToAction(nameof(Login));
        }
    }
}
