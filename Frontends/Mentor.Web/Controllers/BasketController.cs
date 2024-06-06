using Mentor.Web.Models.Basket;
using Mentor.Web.Models.Discount;
using Mentor.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Web.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var course = await _catalogService.GetCourseById(id);

            var basketItem = new BasketItemViewModel();
            basketItem.Quantity = 1;
            basketItem.CourseId = course.Id;
            basketItem.CourseName = course.Name;
            basketItem.Price = course.Price;

            await _basketService.AddBasketItem(basketItem);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
        {
            if (!ModelState.IsValid)
            {
                TempData["discountError"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).FirstOrDefault();
                return RedirectToAction(nameof(Index));
            }

            var discountStatus = await _basketService.ApplyDiscount(discountApplyInput.Code);

            TempData["discountStatus"] = discountStatus;

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CancelAppliedDiscount()
        {
            await _basketService.CancelAppliedDiscount();

            return RedirectToAction(nameof(Index));
        }
    }
}
