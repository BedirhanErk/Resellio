using Mentor.Services.Order.Domain.Core;

namespace Mentor.Services.Order.Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public string CourseId { get; private set; }
        public string CourseName { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUrl { get; private set; }

        public OrderItem()
        {
            
        }

        public OrderItem(string courseId, string courseName, decimal price, string pictureUrl)
        {
            CourseId = courseId;
            CourseName = courseName;
            Price = price;
            PictureUrl = pictureUrl;
        }

        public void UpdateOrderItem(string courseName, decimal price, string pictureUrl)
        {
            CourseName = courseName;
            Price = price;
            PictureUrl = pictureUrl;
        }
    }
}
