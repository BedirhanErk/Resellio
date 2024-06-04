using Mentor.Shared.Services;
using Mentor.Web.Models.Catalog;
using Mentor.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentor.Web.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CourseController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _catalogService.GetAllCoursesByUserId(_sharedIdentityService.UserId);

            return View(courses);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategories();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateInput courseCreateInput)
        {
            var categories = await _catalogService.GetAllCategories();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            if (!ModelState.IsValid)
                return View();

            courseCreateInput.UserId = _sharedIdentityService.UserId;

            await _catalogService.CreateCourse(courseCreateInput);

            return RedirectToAction(nameof(Index));
        }
    }
}
