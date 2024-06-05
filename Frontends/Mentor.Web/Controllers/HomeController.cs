using Mentor.Web.Exceptions;
using Mentor.Web.Services.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UdemyRabbitMQWeb.Excel.Models;

namespace Mentor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogService _catalogService;

        public HomeController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _catalogService.GetAllCourses();

            return View(courses);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var course = await _catalogService.GetCourseById(id);

            return View(course);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (errorFeature != null && errorFeature.Error is UnAuthorizeException)
                return RedirectToAction(nameof(AuthController.Logout), "Auth");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
