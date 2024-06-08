using MassTransit;
using Mentor.Services.Payment.Models;
using Mentor.Shared.ControllerBases;
using Mentor.Shared.Dtos;
using Mentor.Shared.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Services.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CustomBaseController
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public PaymentController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> ReceivePayment(PaymentDto payment)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue: create-order-service"));

            var createOrderMessageCommand = new CreateOrderMessageCommand();
            createOrderMessageCommand.BuyerId = payment.Order.BuyerId;

            foreach (var item in payment.Order.OrderItems)
            {
                var newOrderItem = new OrderItem(); 
                newOrderItem.CourseId = item.CourseId;
                newOrderItem.CourseName = item.CourseName;
                newOrderItem.Price = item.Price;
                newOrderItem.PictureUrl = item.PictureUrl;
                createOrderMessageCommand.OrderItems.Add(newOrderItem);
            }

            createOrderMessageCommand.Province = payment.Order.Address.Province;
            createOrderMessageCommand.District = payment.Order.Address.District;
            createOrderMessageCommand.Street = payment.Order.Address.Street;
            createOrderMessageCommand.ZipCode = payment.Order.Address.ZipCode;
            createOrderMessageCommand.Line = payment.Order.Address.Line;

            await sendEndpoint.Send(createOrderMessageCommand);

            return CreateActionResultInstance(Shared.Dtos.Response<NoContent>.Success(200));
        }
    }
}
