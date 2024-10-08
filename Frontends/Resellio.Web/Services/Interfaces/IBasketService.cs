﻿using Resellio.Web.Models.Basket;

namespace Resellio.Web.Services.Interfaces
{
    public interface IBasketService
    {
        Task<BasketViewModel> GetBasket();
        Task<long> GetBasketItemCount();
        Task<bool> SaveOrUpdate(BasketViewModel basketViewModel);
        Task<bool> Delete();
        Task AddBasketItem(BasketItemViewModel basketItemViewModel);
        Task<bool> RemoveBasketItem(string productId);
        Task<bool> ApplyDiscount(string discountCode);
        Task<bool> CancelAppliedDiscount();
    }
}
