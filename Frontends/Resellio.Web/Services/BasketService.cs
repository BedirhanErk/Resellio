using Resellio.Shared.Dtos;
using Resellio.Web.Helpers;
using Resellio.Web.Models.Basket;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IDiscountService _discountService;
        private readonly PhotoHelper _photoHelper;

        public BasketService(HttpClient httpClient, IDiscountService discountService, PhotoHelper photoHelper)
        {
            _httpClient = httpClient;
            _discountService = discountService;
            _photoHelper = photoHelper;
        }

        public async Task<BasketViewModel> GetBasket()
        {
            var response = await _httpClient.GetAsync("basket");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<BasketViewModel>>();

            return responseSuccess.Data;
        }

        public async Task<bool> SaveOrUpdate(BasketViewModel basketViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("basket", basketViewModel);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete()
        {
            var response = await _httpClient.DeleteAsync("basket");

            return response.IsSuccessStatusCode;
        }

        public async Task AddBasketItem(BasketItemViewModel basketItemViewModel)
        {
            var basket = await GetBasket();

            if (basket != null)
            {
                if (!basket.BasketItems.Any(x=> x.ProductId == basketItemViewModel.ProductId))
                {
                    basketItemViewModel.ProductPicture = _photoHelper.GetPhotoUrl(basketItemViewModel.ProductPicture);

                    basket.BasketItems.Add(basketItemViewModel);
                }
            }
            else
            {
                basketItemViewModel.ProductPicture = _photoHelper.GetPhotoUrl(basketItemViewModel.ProductPicture);

                basket = new BasketViewModel();
                basket.BasketItems.Add(basketItemViewModel);
            }

            await SaveOrUpdate(basket);
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var basket = await GetBasket();

            if (basket == null)
                return false;

            var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            if (basketItem == null)
                return false;

            var deleteResult = basket.BasketItems.Remove(basketItem);

            if (!deleteResult)
                return false;

            if (!basket.BasketItems.Any())
                basket.DiscountCode = null;

            return await SaveOrUpdate(basket);
        }

        public async Task<bool> ApplyDiscount(string discountCode)
        {
            await CancelAppliedDiscount();

            var basket = await GetBasket();

            if (basket == null)
                return false;

            var discount = await _discountService.GetDiscount(discountCode);

            if (discount == null)
                return false;

            basket.ApplyDiscount(discount.Code, discount.Rate);

            return await SaveOrUpdate(basket);
        }

        public async Task<bool> CancelAppliedDiscount()
        {
            var basket = await GetBasket();

            if (basket == null || basket.DiscountCode == null)
                return false;

            basket.CancelDiscount();

            return await SaveOrUpdate(basket);
        }
    }
}
