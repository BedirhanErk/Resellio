using MassTransit;
using Resellio.Services.Order.Infrastructure;
using Resellio.Shared.Messages;
using Microsoft.EntityFrameworkCore;

namespace Resellio.Services.Order.Application.Consumers
{
    public class ProductChangedEventConsumer : IConsumer<ProductChangedEvent>
    {
        private readonly OrderDbContext _orderDbContext;

        public ProductChangedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<ProductChangedEvent> context)
        {
            var orderItems = await _orderDbContext.OrderItems.Where(x => x.ProductId == context.Message.ProductId).ToListAsync();

            orderItems.ForEach(x => {
                x.UpdateOrderItem(context.Message.ProductName, x.Price, x.PictureUrl);
            });

            await _orderDbContext.SaveChangesAsync();
        }
    }
}
