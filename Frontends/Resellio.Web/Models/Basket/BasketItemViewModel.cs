namespace Resellio.Web.Models.Basket
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductPicture { get; set; }

        public decimal Price { get; set; }


        private decimal? DiscountPrice;

        public decimal CurrentPrice
        {
            get => DiscountPrice != null ? DiscountPrice.Value : Price;
        }

        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountPrice = discountPrice;
        }
    }
}
