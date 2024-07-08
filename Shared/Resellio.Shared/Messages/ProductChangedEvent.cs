namespace Resellio.Shared.Messages
{
    public class ProductChangedEvent
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPicture { get; set; }
    }
}
