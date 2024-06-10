using System.ComponentModel.DataAnnotations;

namespace Resellio.Web.Models.Catalog
{
    public class FeatureViewModel
    {
        [Required]
        public int Duration { get; set; }
    }
}
