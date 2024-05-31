using MediatR;
using Mentor.Services.Order.Application.Dtos;
using Mentor.Shared.Dtos;

namespace Mentor.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
