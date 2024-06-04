using Mentor.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
