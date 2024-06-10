using Resellio.Web.Models.Order;

namespace Resellio.Web.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetOrders();
        Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput);
        Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfoInput);
    }
}
