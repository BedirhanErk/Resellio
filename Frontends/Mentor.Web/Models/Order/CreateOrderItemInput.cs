namespace Mentor.Web.Models.Order
{
    public class CreateOrderItemInput
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
