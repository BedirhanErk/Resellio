namespace Resellio.Services.Catalog.Dtos
{
    public class ProductDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string CategoryId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public FeatureDto Feature { get; set; }

        public CategoryDto Category { get; set; }
    }
}
