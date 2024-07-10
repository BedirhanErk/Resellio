using System.ComponentModel.DataAnnotations;

namespace Resellio.Web.Models.Order
{
    public class CheckoutInfoInput
    {
        public string Province { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string Line { get; set; }

        public string Name { get; set; }

        public string CardNumber { get; set; }

        public string Expiration { get; set; }

        public string CVV { get; set; }
    }
}
