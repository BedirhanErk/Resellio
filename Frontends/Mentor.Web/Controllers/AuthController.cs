using Microsoft.AspNetCore.Mvc;

namespace Mentor.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
