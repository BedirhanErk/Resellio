using Mentor.Web.Models.Basket;
using Mentor.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public BasketController(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await _basketService.GetBasket();

            return View(basket);
        }

        public async Task<IActionResult> AddBasketItem(string courseId)
        {
            var course = await _catalogService.GetCourseById(courseId);

            var basketItem = new BasketItemViewModel();
            basketItem.Quantity = 1;
            basketItem.CourseId = course.Id;
            basketItem.CourseName = course.Name;
            basketItem.Price = course.Price;

            await _basketService.AddBasketItem(basketItem);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveBasketItem(string courseId)
        {
            await _basketService.RemoveBasketItem(courseId);

            return RedirectToAction(nameof(Index));
        }
    }
}
