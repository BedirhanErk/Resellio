using MediatR;
using Resellio.Services.Order.Application.Dtos;
using Resellio.Shared.Dtos;

namespace Resellio.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
