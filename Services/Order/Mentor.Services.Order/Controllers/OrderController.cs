using MediatR;
using Mentor.Services.Order.Application.Commands;
using Mentor.Services.Order.Application.Queries;
using Mentor.Shared.ControllerBases;
using Mentor.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Services.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrderController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _mediator.Send(new GetOrdersByUserIdQuery { UserId = _sharedIdentityService.UserId });

            return CreateActionResultInstance(response);
        }

        [HttpPost]  
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            var response = await _mediator.Send(createOrderCommand);

            return CreateActionResultInstance(response);
        }
    }
}
