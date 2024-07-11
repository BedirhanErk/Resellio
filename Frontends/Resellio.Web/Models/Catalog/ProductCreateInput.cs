using System.ComponentModel.DataAnnotations;

namespace Resellio.Web.Models.Catalog
{
    public class ProductCreateInput
    {
        public string? UserId { get; set; }
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Picture { get; set; }

        public string Description { get; set; }

        public IFormFile PhotoFormFile { get; set; }
    }
}
