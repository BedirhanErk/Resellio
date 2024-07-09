using Resellio.Services.Basket.Dtos;
using Resellio.Shared.Dtos;

namespace Resellio.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<long>> GetBasketItemCount(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);
    }
}
