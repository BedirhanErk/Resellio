namespace Resellio.Web.Models.Order
{
    public class CreateOrderInput
    {
        public string BuyerId { get; set; }
        public List<CreateOrderItemInput> OrderItems { get; set; }
        public CreateAddressInput Address { get; set; }
    }
}
