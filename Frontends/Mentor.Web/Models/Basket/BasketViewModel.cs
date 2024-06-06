namespace Mentor.Web.Models.Basket
{
    public class BasketViewModel
    {
        public BasketViewModel()
        {
            _basketItems = new List<BasketItemViewModel>();
        }

        public string UserId { get; set; }

        public string DiscountCode { get; set; }

        public int? DiscountRate { get; set; }

        private List<BasketItemViewModel> _basketItems;

        public List<BasketItemViewModel> BasketItems
        {
            get
            {
                if (HasDiscount)
                {
                    foreach (var item in _basketItems)
                    {
                        var discountPrice = item.Price * ((decimal)DiscountRate.Value / 100);
                        item.AppliedDiscount(Math.Round(item.Price - discountPrice, 2));
                    }
                }

                return _basketItems;
            }
            set
            {
                _basketItems = value;
            }
        }

        public decimal TotalPrice
        {
            get => _basketItems.Sum(x => x.CurrentPrice * x.Quantity);
        }

        public bool HasDiscount 
        {
            get => !String.IsNullOrEmpty(DiscountCode) && DiscountRate.HasValue;
        }

        public void ApplyDiscount(string discountCode, int discountRate)
        {
            DiscountCode = discountCode;
            DiscountRate = discountRate;
        }

        public void CancelDiscount()
        {
            DiscountCode = null;
            DiscountRate = null;
        }
    }
}
