using Mentor.Web.Models.Basket;

namespace Mentor.Web.Services.Interfaces
{
    public interface IBasketService
    {
        Task<BasketViewModel> GetBasket(string userId);
        Task<bool> SaveOrUpdate(BasketViewModel basketViewModel);
        Task<bool> Delete(string userId);
        Task AddBasketItem(BasketItemViewModel basketItemViewModel);
        Task<bool> RemoveBasketItem(string courseId);
        Task<bool> ApplyDiscount(string discountCode);
        Task<bool> CancelApplyDiscount();
    }
}
