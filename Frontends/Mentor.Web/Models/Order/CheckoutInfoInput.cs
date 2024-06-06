using System.ComponentModel.DataAnnotations;

namespace Mentor.Web.Models.Order
{
    public class CheckoutInfoInput
    {
        public string Province { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Address")]
        public string Line { get; set; }

        [Display(Name = "Name on card")]
        public string Name { get; set; }

        [Display(Name = "Card number")]
        public string CardNumber { get; set; }

        [Display(Name = "Expiration date")]
        public string Expiration { get; set; }

        [Display(Name = "Security code")]
        public string CVV { get; set; }
    }
}
