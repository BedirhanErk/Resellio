using Resellio.Services.Basket.Dtos;
using Resellio.Services.Basket.Services;
using Resellio.Shared.ControllerBases;
using Resellio.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Resellio.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var response = await _basketService.GetBasket(_sharedIdentityService.UserId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            basketDto.UserId = _sharedIdentityService.UserId;

            var response = await _basketService.SaveOrUpdate(basketDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var response = await _basketService.Delete(_sharedIdentityService.UserId);

            return CreateActionResultInstance(response);
        }
    }
}
