using Microsoft.AspNetCore.Mvc;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.ViewComponents
{
    public class CartItemCount : ViewComponent
    {
        private readonly IBasketService _basketService;

        public CartItemCount(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itemCount = await _basketService.GetBasketItemCount();

            return View(itemCount);
        }
    }
}
