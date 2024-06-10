﻿using Resellio.Web.Models.Order;
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
