namespace Resellio.Web.Models.Order
{
    public class CreateOrderItemInput
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
