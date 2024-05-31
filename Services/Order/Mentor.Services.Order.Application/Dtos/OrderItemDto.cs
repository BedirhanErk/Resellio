namespace Mentor.Services.Order.Application.Dtos
{
    public class OrderItemDto
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
