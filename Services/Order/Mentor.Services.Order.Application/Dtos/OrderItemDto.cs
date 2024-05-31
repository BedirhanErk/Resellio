namespace Mentor.Services.Order.Application.Dtos
{
    public class OrderItemDto
    {
        public string CourseId { get; private set; }
        public string CourseName { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUrl { get; private set; }
    }
}
