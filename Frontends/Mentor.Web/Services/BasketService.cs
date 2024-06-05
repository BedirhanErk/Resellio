using Mentor.Shared.Dtos;
using Mentor.Web.Models.Basket;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
                if (!basket.BasketItems.Any(x=> x.CourseId == basketItemViewModel.CourseId))
                    basket.BasketItems.Add(basketItemViewModel);
            }
            else
            {
                basket = new BasketViewModel();
                basket.BasketItems = [basketItemViewModel];
            }

            await SaveOrUpdate(basket);
        }

        public async Task<bool> RemoveBasketItem(string courseId)
        {
            var basket = await GetBasket();

            if (basket == null)
                return false;

            var basketItem = basket.BasketItems.FirstOrDefault(x => x.CourseId == courseId);

            if (basketItem == null)
                return false;

            var deleteResult = basket.BasketItems.Remove(basketItem);

            if (!deleteResult)
                return false;

            if (!basket.BasketItems.Any())
                basket.DiscountCode = null;

            return await SaveOrUpdate(basket);
        }

        public Task<bool> ApplyDiscount(string discountCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CancelApplyDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
