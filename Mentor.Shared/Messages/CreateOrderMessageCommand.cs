using System.Collections.Generic;

namespace Mentor.Shared.Messages
{
    public class CreateOrderMessageCommand
    {
        public string BuyerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Line { get; set; }
    }

    public class OrderItem
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
