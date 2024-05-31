using MediatR;
using Mentor.Services.Order.Application.Commands;
using Mentor.Services.Order.Application.Dtos;
using Mentor.Services.Order.Infrastructure;
using Mentor.Shared.Dtos;

namespace Mentor.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _dbContext;

        public CreateOrderCommandHandler(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Domain.OrderAggregate.Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.CourseId, x.CourseName, x.Price, x.PictureUrl);
            });

            await _dbContext.Orders.AddAsync(newOrder);
            await _dbContext.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }
}
