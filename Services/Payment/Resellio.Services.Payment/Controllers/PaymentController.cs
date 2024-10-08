﻿using Mass = MassTransit;
using Resellio.Services.Payment.Models;
using Resellio.Shared.ControllerBases;
using Resellio.Shared.Dtos;
using Resellio.Shared.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Resellio.Services.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CustomBaseController
    {
        private readonly Mass.ISendEndpointProvider _sendEndpointProvider;

        public PaymentController(Mass.ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> ReceivePayment(PaymentDto payment)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order"));

            var createOrderMessageCommand = new CreateOrderMessageCommand();
            createOrderMessageCommand.BuyerId = payment.Order.BuyerId;

            foreach (var item in payment.Order.OrderItems)
            {
                var newOrderItem = new OrderItem(); 
                newOrderItem.ProductId = item.ProductId;
                newOrderItem.ProductName = item.ProductName;
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

            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
