using Mentor.Web.Models.Order;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class OrderService : IOrderService
    {
        public Task<List<OrderViewModel>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
        {
            throw new NotImplementedException();
        }

        public Task SuspendOrder(CheckoutInfoInput checkoutInfoInput)
        {
            throw new NotImplementedException();
        }
    }
}
