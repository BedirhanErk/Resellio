using Resellio.Web.Models.Order;

namespace Resellio.Web.Models.Payment
{
    public class PaymentInfoInput
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public decimal TotalPrice { get; set; }
        public CreateOrderInput Order { get; set; }
    }
}
