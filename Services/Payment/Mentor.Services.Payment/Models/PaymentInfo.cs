namespace Mentor.Services.Payment.Models
{
    public class PaymentInfo
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
