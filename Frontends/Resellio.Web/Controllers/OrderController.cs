using Resellio.Web.Models.Order;
using Resellio.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Resellio.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public OrderController(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Checkout()
        {
            var basket = await _basketService.GetBasket();

            ViewBag.basket = basket;

            return View(new CheckoutInfoInput());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutInfoInput checkoutInfoInput)
        {
            if (checkoutInfoInput.Province == "" || checkoutInfoInput.Province == null)
                ModelState.AddModelError("Province", "Province is required.");

            if (checkoutInfoInput.District == "" || checkoutInfoInput.District == null)
                ModelState.AddModelError("District", "District is required.");
            
            if (checkoutInfoInput.Street == "" || checkoutInfoInput.Street == null)
                ModelState.AddModelError("Street", "Street is required.");

            if (checkoutInfoInput.ZipCode == "" || checkoutInfoInput.ZipCode == null)
                ModelState.AddModelError("ZipCode", "Zip Code is required.");

            if (checkoutInfoInput.Line == "" || checkoutInfoInput.Line == null)
                ModelState.AddModelError("Line", "Address is required.");

            if (checkoutInfoInput.Name == "" || checkoutInfoInput.Name == null)
                ModelState.AddModelError("Name", "Name on Card is required.");

            if (checkoutInfoInput.CardNumber == "" || checkoutInfoInput.CardNumber == null)
                ModelState.AddModelError("CardNumber", "Card Number is required.");

            if (checkoutInfoInput.Expiration == "" || checkoutInfoInput.Expiration == null)
                ModelState.AddModelError("Expiration", "Expiry Date is required.");

            if (checkoutInfoInput.CVV == "" || checkoutInfoInput.CVV == null)
                ModelState.AddModelError("CVV", "CVV is required.");

            if (!ModelState.IsValid)
            {
                var basket = await _basketService.GetBasket();

                ViewBag.basket = basket;

                return View();
            }

            var orderStatus = await _orderService.SuspendOrder(checkoutInfoInput);

            if (!orderStatus.IsSuccessful)
            {
                var basket = await _basketService.GetBasket();

                ViewBag.basket = basket;

                ViewBag.error = orderStatus.Error;

                return View();
            }

            return RedirectToAction(nameof(SuccessfulCheckout));
        }

        public IActionResult SuccessfulCheckout()
        {
            return View();
        }

        public async Task<IActionResult> CheckoutHistory()
        {
            var orders = await _orderService.GetOrders();

            return View(orders);
        }
    }
}
