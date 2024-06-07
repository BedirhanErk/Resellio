﻿using Mentor.Shared.Dtos;
using Mentor.Shared.Services;
using Mentor.Web.Models.Order;
using Mentor.Web.Models.Payment;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrderService(HttpClient httpClient, IPaymentService paymentService, IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _httpClient = httpClient;
            _paymentService = paymentService;
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<List<OrderViewModel>> GetOrders()
        {
            var response = await _httpClient.GetAsync("order");

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<OrderViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
        {
            var basket = await _basketService.GetBasket();

            var payment = new PaymentInfoInput();
            payment.Name = checkoutInfoInput.Name;
            payment.CardNumber = checkoutInfoInput.CardNumber;
            payment.Expiration = checkoutInfoInput.Expiration;
            payment.CVV = checkoutInfoInput.CVV;
            payment.TotalPrice = basket.TotalPrice;

            var paymentResponse = await _paymentService.ReceivePayment(payment);

            if (!paymentResponse)
                return new OrderCreatedViewModel() { IsSuccessful = false, Error = "Payment not received." };

            var createOrderInput = new CreateOrderInput();
            createOrderInput.BuyerId = _sharedIdentityService.UserId;

            createOrderInput.OrderItems = new List<CreateOrderItemInput>();
            foreach (var item in basket.BasketItems)
            {
                var orderItem = new CreateOrderItemInput();
                orderItem.CourseId = item.CourseId;
                orderItem.CourseName = item.CourseName;
                orderItem.Price = item.CurrentPrice;
                orderItem.PictureUrl = "";
                createOrderInput.OrderItems.Add(orderItem);
            }

            createOrderInput.Address = new CreateAddressInput();
            createOrderInput.Address.Province = checkoutInfoInput.Province;
            createOrderInput.Address.District = checkoutInfoInput.District;
            createOrderInput.Address.Street = checkoutInfoInput.Street;
            createOrderInput.Address.ZipCode = checkoutInfoInput.ZipCode;
            createOrderInput.Address.Line = checkoutInfoInput.Line;

            var response = await _httpClient.PostAsJsonAsync("order", createOrderInput);

            if (!response.IsSuccessStatusCode)
                return new OrderCreatedViewModel() { IsSuccessful = false, Error = "Order could not be created." };

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<OrderCreatedViewModel>>();
            responseSuccess.Data.IsSuccessful = true;

            await _basketService.Delete();

            return responseSuccess.Data;
        }

        public Task SuspendOrder(CheckoutInfoInput checkoutInfoInput)
        {
            throw new NotImplementedException();
        }
    }
}