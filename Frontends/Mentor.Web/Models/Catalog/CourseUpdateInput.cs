using System.ComponentModel.DataAnnotations;

namespace Mentor.Web.Models.Catalog
{
    public class CourseUpdateInput
    {
        [Required]
        public string Id { get; set; }

        public string? UserId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Picture { get; set; }

        public string? Description { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Required]
        [Display(Name = "Picture")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
