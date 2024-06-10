using MassTransit;
using Resellio.Services.Basket.Dtos;
using Resellio.Services.Basket.Services;
using Resellio.Shared.Messages;
using System.Text.Json;

namespace Resellio.Services.Basket.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisService _redisService;

        public CourseNameChangedEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(context.Message.UserId);

            if (!String.IsNullOrEmpty(existBasket))
            {
                var basket = JsonSerializer.Deserialize<BasketDto>(existBasket);

                if (basket != null && basket.BasketItems.Count > 0)
                {
                    foreach (var item in basket.BasketItems.Where(x => x.CourseId == context.Message.CourseId).ToList())
                    {
                        item.CourseName = context.Message.UpdatedName;          
                    }

                    await _redisService.GetDb().StringSetAsync(context.Message.UserId, JsonSerializer.Serialize(basket));
                }
            }
        }
    }
}
