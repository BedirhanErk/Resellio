using Mentor.Services.Order.Domain.Core;

namespace Mentor.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
            
        }

        public Order(string buyerId, Address address) 
        {
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
            _orderItems = new List<OrderItem>();
        }

        public void AddOrderItem(string courseId, string courseName, decimal price, string pictureUrl)
        {
            var existCourse = _orderItems.Any(x => x.CourseId == courseId);

            if (!existCourse)
            {
                var newOrderItem = new OrderItem(courseId, courseName, price, pictureUrl);
                _orderItems.Add(newOrderItem);
            }
        }

        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
