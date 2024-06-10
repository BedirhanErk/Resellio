using Resellio.Web.Models.Payment;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
        {
            var response = await _httpClient.PostAsJsonAsync("payment", paymentInfoInput);

            return response.IsSuccessStatusCode;
        }
    }
}
