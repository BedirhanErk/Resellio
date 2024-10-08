﻿using Resellio.Shared.Dtos;
using Resellio.Web.Models.Discount;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DiscountViewModel> GetDiscount(string discountCode)
        {
            var response = await _httpClient.GetAsync($"discount/GetByCode/{discountCode}");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<DiscountViewModel>>();

            return responseSuccess.Data;
        }
    }
}
