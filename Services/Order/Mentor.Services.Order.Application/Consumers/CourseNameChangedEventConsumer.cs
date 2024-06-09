using MassTransit;
using Mentor.Services.Order.Infrastructure;
using Mentor.Shared.Messages;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Services.Order.Application.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly OrderDbContext _orderDbContext;

        public CourseNameChangedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var orderItems = await _orderDbContext.OrderItems.Where(x => x.CourseId == context.Message.CourseId).ToListAsync();

            orderItems.ForEach(x => {
                x.UpdateOrderItem(context.Message.UpdatedName, x.Price, x.PictureUrl);
            });

            await _orderDbContext.SaveChangesAsync();
        }
    }
}
