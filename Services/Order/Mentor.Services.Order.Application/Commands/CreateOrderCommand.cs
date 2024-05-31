using MediatR;
using Mentor.Services.Order.Application.Dtos;
using Mentor.Shared.Dtos;

namespace Mentor.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
    }
}
