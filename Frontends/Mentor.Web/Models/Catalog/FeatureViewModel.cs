using System.ComponentModel.DataAnnotations;

namespace Mentor.Web.Models.Catalog
{
    public class FeatureViewModel
    {
        [Required]
        public int Duration { get; set; }
    }
}
