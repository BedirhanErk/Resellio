using System.ComponentModel.DataAnnotations;

namespace Mentor.Web.Models.Catalog
{
    public class CourseCreateInput
    {
        public string? UserId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string? Description { get; set; }

        public FeatureViewModel Feature { get; set; }
    }
}
