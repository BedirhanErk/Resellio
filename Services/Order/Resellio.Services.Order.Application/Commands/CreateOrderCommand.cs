using MediatR;
using Resellio.Services.Order.Application.Dtos;
using Resellio.Shared.Dtos;

namespace Resellio.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
    }
}
